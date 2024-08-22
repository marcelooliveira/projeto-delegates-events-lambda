public interface ICaixaEletronico
{
    void Depositar(decimal valor);
    void Extrato();
    void Sacar(decimal valor);
    void VerificarSaldo();

    event SaldoInsuficienteHandler OnSaldoInsuficiente;
}