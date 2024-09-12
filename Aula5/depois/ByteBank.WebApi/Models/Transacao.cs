namespace ByteBank.WebApi.Models
{
    public class Transacao
    {
        public Transacao(string agencia, string conta, char tipo, decimal valor, DateTime dataRegistro)
        {
            Agencia = agencia;
            Conta = conta;
            Tipo = tipo;
            Valor = valor;
            DataRegistro = dataRegistro;
        }

        public string Agencia { get; set; }
        public string Conta { get; set; }
        public char Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}