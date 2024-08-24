namespace ByteBank.CaixaEletronico
{
    public class Conta : IConta
    {
        private decimal saldo = 1000;

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
            return saldo;
        }
    }

    public delegate void SaldoEventHandler(object sender, SaldoEventArgs e);
    public delegate void DepositoEventHandler(object sender, TransacaoEventArgs e);
    public delegate void SaqueEventHandler(object sender, TransacaoEventArgs e);
    public delegate void SaldoInsuficienteEventHandler(object sender, TransacaoEventArgs e);
}
