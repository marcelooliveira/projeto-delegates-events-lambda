using RestSharp;
using System.Globalization;

namespace ByteBank.CaixaEletronico
{
    public class Conta : IConta
    {
        private const string NumeroAgencia = "007";
        private const string NumeroConta = "78901-2";
        private decimal saldo = 1000;
        private object objectLock = new Object();

        public event DepositoEventHandler DepositoEvent;
        public event SaqueEventHandler SaqueEvent;
        public event SaldoInsuficienteEventHandler SaldoInsuficienteEvent;

        public void Sacar(decimal valor)
        {
            if (valor > saldo)
            {
                SaldoInsuficienteEvent?.Invoke(this, new TransacaoEventArgs(saldo, valor));
            }
            else
            {
                saldo -= valor;
                SaqueEvent?.Invoke(this, new TransacaoEventArgs(saldo, valor));
            }
        }

        public void Depositar(decimal valor)
        {
            saldo += valor;
            DepositoEvent?.Invoke(this, new TransacaoEventArgs(saldo, valor));
        }

        public async Task<decimal> ConsultarSaldo()
        {
            var client = new RestClient();
            var request = new RestRequest($"http://localhost:5024/contabancaria/{NumeroAgencia}/{NumeroConta}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            return decimal.Parse(response.Content, CultureInfo.InvariantCulture);
        }
    }

    public delegate void SaldoEventHandler(object sender, SaldoEventArgs e);
    public delegate void DepositoEventHandler(object sender, TransacaoEventArgs e);
    public delegate void SaqueEventHandler(object sender, TransacaoEventArgs e);
    public delegate void SaldoInsuficienteEventHandler(object sender, TransacaoEventArgs e);
}
