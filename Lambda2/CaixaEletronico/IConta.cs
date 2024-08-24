namespace CaixaEletronico
{
    public interface IConta
    {
        void Depositar(decimal valor);
        void Sacar(decimal valor);
        Task<decimal> ConsultarSaldo();
    }
}
