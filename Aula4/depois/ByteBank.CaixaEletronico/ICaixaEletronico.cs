namespace ByteBank.CaixaEletronico
{
    public interface ICaixaEletronico
    {
        //decimal Saldo();
        decimal Saldo { get; }
        void Depositar(decimal valor);
        void Sacar(decimal valor);
        string Extrato();

        event SaldoInsuficienteEventHandler OnSaldoInsuficiente;
    }
}
