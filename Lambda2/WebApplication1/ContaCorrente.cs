namespace WebApplication1
{
    public class ContaCorrente
    {
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public decimal Saldo { get; set; }
        public DateTime UltimoAcesso { get; set; }

        // Construtor da classe
        public ContaCorrente(string agencia, string conta, decimal saldo, DateTime ultimoAcesso)
        {
            Agencia = agencia;
            Conta = conta;
            Saldo = saldo;
            UltimoAcesso = ultimoAcesso;
        }

        // M�todo para exibir informa��es da conta
        public override string ToString()
        {
            return $"Ag�ncia: {Agencia}, Conta: {Conta}, Saldo: {Saldo:C}, �ltimo Acesso: {UltimoAcesso}";
        }

        // M�todo est�tico para inicializar a lista de contas

    }
}