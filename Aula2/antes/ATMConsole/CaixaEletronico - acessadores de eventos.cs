public delegate void ConsultaBancaria();
public delegate void TransacaoBancaria(decimal amount);
//public delegate void SaldoInsuficienteHandler();

public class SaldoInsuficienteEventArgs : EventArgs
{
    public decimal Saldo { get; }
    public decimal Saque { get; }

    public SaldoInsuficienteEventArgs(decimal saldo, decimal saque)
    {
        Saldo = saldo;
        Saque = saque;
    }
}

public delegate void SaldoInsuficienteHandler(object sender, SaldoInsuficienteEventArgs e);

public class CaixaEletronico : ICaixaEletronico
{
    private decimal saldo;
    private List<string> transacoes = new List<string>();
    // Evento para saldo insuficiente
    //public event SaldoInsuficienteHandler SaldoInsuficiente;

    //Enfatizar que o EventHandler abaixo é um delegate:
    //      public delegate void EventHandler(object? sender, EventArgs e);

    //event EventHandler SaldoInsuficienteEvent;
    event SaldoInsuficienteHandler SaldoInsuficienteEvent;


    object objectLock = new Object();

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
            //Console.WriteLine("Saldo insuficiente.");
            // Dispara o evento se o saldo for insuficiente
            //SaldoInsuficiente?.Invoke();
            //SaldoInsuficienteEvent?.Invoke(this, EventArgs.Empty);
            SaldoInsuficienteEvent?.Invoke(this, new SaldoInsuficienteEventArgs(saldo, valor));
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

    //// Método para assinar o evento
    //public void AssinarSaldoInsuficiente()
    //{
    //    SaldoInsuficiente += InformarSaldoInsuficiente;
    //}

    //// Método para cancelar a assinatura do evento
    //public void CancelarAssinatura()
    //{
    //    SaldoInsuficiente -= InformarSaldoInsuficiente;
    //}

    event SaldoInsuficienteHandler ICaixaEletronico.OnSaldoInsuficiente
    {
        add
        {
            lock (objectLock)
            {
                SaldoInsuficienteEvent += value;
            }
        }
        remove
        {
            lock (objectLock)
            {
                SaldoInsuficienteEvent -= value;
            }
        }
    }
}