﻿//public class CaixaEletronico : ICaixaEletronico
//{
//    private decimal saldo;
//    private List<ItemExtrato> itensExtrato = new();

//    public CaixaEletronico()
//    {
//        saldo = 100;
//        var item = new ItemExtrato
//        {
//            Data = DateTime.Now.AddDays(-2),
//            Descricao = "Saldo Inicial",
//            Valor = saldo,
//            Sinal = SinalOperacao.Credito
//        };
//        itensExtrato.Add(item);
//    }

//    public void Saldo()
//    {
//        ImprimirSaldo();
//    }

//    public void Extrato()
//    {
//        ImprimirCabecalho();

//        foreach (var item in itensExtrato)
//        {
//            ImprimirItemExtrato(item);
//        }
//        Console.ForegroundColor = ConsoleColor.White;

//        ImprimirSaldo();
//    }

//    public void Depositar(decimal valor)
//    {
//        saldo += valor;
//        var item = new ItemExtrato
//        {
//            Data = DateTime.Now,
//            Descricao = "Depósito",
//            Valor = valor,
//            Sinal = SinalOperacao.Credito
//        };

//        ImprimirCabecalho();
//        itensExtrato.Add(item);
//        ImprimirItemExtrato(item);
//    }

//    public void Sacar(decimal valor)
//    {
//        if (valor > saldo)
//        {
//            Console.WriteLine("Saldo insuficiente.");
//        }
//        else
//        {
//            saldo -= valor;
//            var item = new ItemExtrato
//            {
//                Data = DateTime.Now,
//                Descricao = "Saque",
//                Valor = valor,
//                Sinal = SinalOperacao.Debito
//            };

//            ImprimirCabecalho();
//            itensExtrato.Add(item);
//            ImprimirItemExtrato(item);
//        }
//    }

//    public void AplicarPoupanca(decimal valor)
//    {
//        if (valor > saldo)
//        {
//            Console.WriteLine("Saldo insuficiente.");
//        }
//        else
//        {
//            saldo -= valor;
//            var item = new ItemExtrato
//            {
//                Data = DateTime.Now,
//                Descricao = "Aplicação em Poupança",
//                Valor = valor,
//                Sinal = SinalOperacao.Debito
//            };

//            ImprimirCabecalho();
//            itensExtrato.Add(item);
//            ImprimirItemExtrato(item);
//        }
//    }

//    private static void ImprimirItemExtrato(ItemExtrato item)
//    {
//        Console.ForegroundColor = item.Sinal == SinalOperacao.Credito
//            ? ConsoleColor.Green
//            : ConsoleColor.Red;
//        Console.WriteLine(item);
//        Console.ForegroundColor = ConsoleColor.White;
//    }

//    private static void ImprimirCabecalho()
//    {
//        Console.WriteLine(new string('=', 80));
//        Console.WriteLine("{0,-20} {1,-25} {2,18}", "Data/Hora", "Descrição", "Valor (R$)");
//        Console.WriteLine(new string('=', 80));
//    }

//    private void ImprimirSaldo()
//    {
//        Console.WriteLine(new string('=', 80));
//        string valor = saldo.ToString("N2").PadLeft(18);
//        Console.WriteLine("{0,-20} {1,-25} {2,18}", string.Empty, "Saldo", valor);
//        Console.WriteLine(new string('=', 80));
//    }
//}

//class ItemExtrato
//{
//    public DateTime Data { get; set; }
//    public string Descricao { get; set; }
//    public SinalOperacao Sinal { get; set; }
//    public decimal Valor { get; set; }

//    public override string ToString()
//    {
//        string data = Data.ToString("dd/MM/yyyy HH:mm:ss");
//        string descricao = Descricao.Length > 50 ? Descricao.Substring(0, 50) : Descricao;
//        string valor = (Valor * (int)Sinal).ToString("N2").PadLeft(18);

//        return string.Format("{0,-20} {1,-25} {2}", data, descricao, valor);
//    }
//}

//enum SinalOperacao
//{
//    Credito = 1,
//    Debito = -1
//}
