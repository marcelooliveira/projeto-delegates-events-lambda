namespace CaixaEletronico
{
    public interface IContaCorrente
    {
        void Depositar(decimal valor);
        void Sacar(decimal valor);
        decimal ConsultarSaldo();

        //event SaldoEventHandler OnSaldoAtualizado;
        //event DepositoEventHandler OnDeposito;
        //event SaqueEventHandler OnSaque;
        //event SaldoInsuficienteEventHandler OnSaldoInsuficiente;
    }
}
