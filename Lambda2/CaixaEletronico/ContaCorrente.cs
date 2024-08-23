using RestSharp;

namespace CaixaEletronico
{
    public class ContaCorrente : IContaCorrente
    {
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

        public decimal ConsultarSaldo()
        {
            //var client = new RestClient();
            //var request = new RestRequest("http://localhost:5024/contabancaria", Method.Get);
            //RestResponse response = await client.ExecuteAsync(request);
            //saldo = decimal.Parse(response.Content);

            return saldo;
        }
    }

    public class SaldoEventArgs : EventArgs
    {
        public decimal Saldo { get; }

        public SaldoEventArgs(decimal saldo)
        {
            Saldo = saldo;
        }
    }

    public class TransacaoEventArgs : SaldoEventArgs
    {
        public decimal ValorTransacao { get; }

        public TransacaoEventArgs(decimal saldo, decimal valorTransacao) : base(saldo)
        {
            ValorTransacao = valorTransacao;
        }
    }

    public delegate void SaldoEventHandler(object sender, SaldoEventArgs e);
    public delegate void DepositoEventHandler(object sender, TransacaoEventArgs e);
    public delegate void SaqueEventHandler(object sender, TransacaoEventArgs e);
    public delegate void SaldoInsuficienteEventHandler(object sender, TransacaoEventArgs e);
}
