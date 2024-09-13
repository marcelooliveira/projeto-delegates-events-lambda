public delegate void ConsultaBancaria();
public delegate void TransacaoBancaria(decimal amount);
public class CaixaEletronico
{
    private decimal saldo;
    private List<string> transacoes = new List<string>();

    public CaixaEletronico()
    {
        saldo = 0;
    }

    public void VerificarSaldo()
    {
        Console.WriteLine("*** VerificarSaldo");
        Console.WriteLine($"Saldo atual: {saldo:C}");
        Console.WriteLine();
    }

    public void Extrato()
    {
        Console.WriteLine("*** Extrato");
        foreach (var item in transacoes) { Console.WriteLine(item); }
        Console.WriteLine();
    }

    public void Depositar(decimal valor)
    {
        Console.WriteLine("*** Depositar");
        saldo += valor;
        string itemExtrato = $"Valor depositado: {valor:C}. Novo saldo: {saldo:C}";
        transacoes.Add(itemExtrato);
        Console.WriteLine(itemExtrato);
        Console.WriteLine();
    }

    public void Sacar(decimal valor)
    {
        Console.WriteLine("*** Sacar");

        if (valor > saldo)
        {
            Console.WriteLine("Saldo insuficiente.");
        }
        else
        {
            saldo -= valor;
            string itemExtrato = $"Valor do saque: {valor:C}. Novo saldo: {saldo:C}";
            transacoes.Add(itemExtrato);
            Console.WriteLine(itemExtrato);
        }
        Console.WriteLine();
    }
}