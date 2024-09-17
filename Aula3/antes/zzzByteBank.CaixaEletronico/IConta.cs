namespace ByteBank.CaixaEletronico
{
    public interface IConta
    {
        void Depositar(decimal valor);
        void Sacar(decimal valor);
        decimal ConsultarSaldo();
    }
}
