﻿//public delegate void SaldoInsuficienteHandler();

public class CaixaEletronico : ICaixaEletronico
{
    private const int LarguraExtrato = 80;
    private decimal saldo;
    private List<ItemExtrato> itensExtrato = new();
    //public event SaldoInsuficienteHandler SaldoInsuficiente;

    //Enfatizar que o EventHandler abaixo é um delegate:
    //      public delegate void EventHandler(object? sender, EventArgs e);

    public event EventHandler OnSaldoInsuficiente;

    public CaixaEletronico()
    {
        saldo = 100;
        var item = new ItemExtrato
        {
            Data = DateTime.Now.AddDays(-2),
            Descricao = "Saldo Inicial",
            Valor = saldo,
            Sinal = SinalOperacao.Credito
        };
        itensExtrato.Add(item);
        //AssinarSaldoInsuficiente();
    }

    public void Saldo()
    {
        ImprimirSaldo();
    }

    public void Extrato()
    {
        ImprimirCabecalho();

        foreach (var item in itensExtrato)
        {
            ImprimirItemExtrato(item);
        }
        Console.ForegroundColor = ConsoleColor.White;

        ImprimirSaldo();
    }

    public void Depositar(decimal valor)
    {
        saldo += valor;
        var item = new ItemExtrato
        {
            Data = DateTime.Now,
            Descricao = "Depósito",
            Valor = valor,
            Sinal = SinalOperacao.Credito
        };

        ImprimirCabecalho();
        itensExtrato.Add(item);
        ImprimirItemExtrato(item);
    }

    public void Sacar(decimal valor)
    {
        //CancelarAssinarSaldoInsuficiente();

        if (valor > saldo)
        {
            //Console.WriteLine("Saldo insuficiente.");
            OnSaldoInsuficiente?.Invoke(this, new EventArgs());
        }
        else
        {
            saldo -= valor;
            var item = new ItemExtrato
            {
                Data = DateTime.Now,
                Descricao = "Saque",
                Valor = valor,
                Sinal = SinalOperacao.Debito
            };

            ImprimirCabecalho();
            itensExtrato.Add(item);
            ImprimirItemExtrato(item);
        }
    }

    public void AplicarPoupanca(decimal valor)
    {
        if (valor > saldo)
        {
            Console.WriteLine("Saldo insuficiente.");
        }
        else
        {
            saldo -= valor;
            var item = new ItemExtrato
            {
                Data = DateTime.Now,
                Descricao = "Aplicação em Poupança",
                Valor = valor,
                Sinal = SinalOperacao.Debito
            };

            ImprimirCabecalho();
            itensExtrato.Add(item);
            ImprimirItemExtrato(item);
        }
    }

    private static void ImprimirItemExtrato(ItemExtrato item)
    {
        Console.ForegroundColor = item.Sinal == SinalOperacao.Credito
            ? ConsoleColor.Green
            : ConsoleColor.Red;
        Console.WriteLine(item);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void ImprimirCabecalho()
    {
        Console.WriteLine(new string('=', LarguraExtrato));
        Console.WriteLine("{0,-20} {1,-25} {2,18}", "Data/Hora", "Descrição", "Valor (R$)");
        Console.WriteLine(new string('=', LarguraExtrato));
    }

    private void ImprimirSaldo()
    {
        Console.WriteLine(new string('=', LarguraExtrato));
        string valor = saldo.ToString("N2").PadLeft(18);
        Console.WriteLine("{0,-20} {1,-25} {2,18}", string.Empty, "Saldo", valor);
        Console.WriteLine(new string('=', LarguraExtrato));
    }

    //private void AssinarSaldoInsuficiente()
    //{
    //    SaldoInsuficiente += MostrarSaldoInsuficiente;
    //}

    //private void CancelarAssinarSaldoInsuficiente()
    //{
    //    SaldoInsuficiente -= MostrarSaldoInsuficiente;
    //}

    //private void MostrarSaldoInsuficiente()
    //{
    //    Console.WriteLine($"Saldo insuficiente.{Environment.NewLine}Contate a central de atendimento do banco ByteBank para solicitar um limite maior no crédito para emergências.");
    //}
}

public class ItemExtrato
{
    public DateTime Data { get; set; }
    public string Descricao { get; set; }
    public SinalOperacao Sinal { get; set; }
    public decimal Valor { get; set; }

    public override string ToString()
    {
        string data = Data.ToString("dd/MM/yyyy HH:mm:ss");
        string descricao = Descricao.Length > 50 ? Descricao.Substring(0, 50) : Descricao;
        string valor = (Valor * (int)Sinal).ToString("N2").PadLeft(18);

        return string.Format("{0,-20} {1,-25} {2}", data, descricao, valor);
    }
}

public enum SinalOperacao
{
    Credito = 1,
    Debito = -1
}
