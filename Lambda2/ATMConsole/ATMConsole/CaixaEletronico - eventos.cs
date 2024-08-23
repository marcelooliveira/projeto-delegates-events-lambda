//public delegate void ConsultaBancaria();
//public delegate void TransacaoBancaria(decimal amount);
//public delegate void SaldoInsuficienteHandler();
//public class CaixaEletronico
//{
//    private decimal saldo;
//    private List<string> transacoes = new List<string>();
//    // Evento para saldo insuficiente
//    public event SaldoInsuficienteHandler SaldoInsuficiente;

//    public CaixaEletronico()
//    {
//        saldo = 0;
//    }

//    public void VerificarSaldo()
//    {
//        Console.WriteLine("*** VerificarSaldo");
//        Console.WriteLine($"Saldo atual: {saldo:C}");
//        Console.WriteLine();
//    }

//    public void Extrato()
//    {
//        Console.WriteLine("*** Extrato");
//        foreach (var item in transacoes) { Console.WriteLine(item); }
//        Console.WriteLine();
//    }

//    public void Depositar(decimal valor)
//    {
//        Console.WriteLine("*** Depositar");
//        saldo += valor;
//        string itemExtrato = $"Valor depositado: {valor:C}. Novo saldo: {saldo:C}";
//        transacoes.Add(itemExtrato);
//        Console.WriteLine(itemExtrato);
//        Console.WriteLine();
//    }

//    public void Sacar(decimal valor)
//    {
//        Console.WriteLine("*** Sacar");

//        if (valor > saldo)
//        {
//            //Console.WriteLine("Saldo insuficiente.");
//            // Dispara o evento se o saldo for insuficiente
//            SaldoInsuficiente?.Invoke();
//        }
//        else
//        {
//            saldo -= valor;
//            string itemExtrato = $"Valor do saque: {valor:C}. Novo saldo: {saldo:C}";
//            transacoes.Add(itemExtrato);
//            Console.WriteLine(itemExtrato);
//        }
//        Console.WriteLine();
//    }

//    // Método para assinar o evento
//    public void AssinarSaldoInsuficiente()
//    {
//        SaldoInsuficiente += InformarSaldoInsuficiente;
//    }

//    // Método para cancelar a assinatura do evento
//    public void CancelarAssinatura()
//    {
//        SaldoInsuficiente -= InformarSaldoInsuficiente;
//    }

//    // Método que será chamado quando o evento for disparado
//    private void InformarSaldoInsuficiente()
//    {
//        Console.WriteLine("Saldo insuficiente. Contate a central de atendimento do banco ByteBank para solicitar um limite maior no crédito para emergências.");
//    }
//}