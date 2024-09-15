﻿//internal class Program
//{
//    private static void Main(string[] args)
//    {

//        new Logo().MostrarBanner();

//        while (true)
//        {
//            MostrarMenu();

//            if (int.TryParse(Console.ReadLine(), out int escolha))
//            {
//                ExecutarEscolha(escolha);
//            }
//            else
//            {
//                Console.WriteLine("Opção inválida. Tente novamente.");
//            }
//        }

//    }
//    static void MostrarBanner()
//    {
//        var bannerLines = new string[]
//        {
//            "▒█▀▀█ █░░█ ▀▀█▀▀ █▀▀ ▒█▀▀█ █▀▀█ █▀▀▄ █░█",
//            "▒█▀▀▄ █▄▄█ ░░█░░ █▀▀ ▒█▀▀▄ █▄▄█ █░░█ █▀▄",
//            "▒█▄▄█ ▄▄▄█ ░░▀░░ ▀▀▀ ▒█▄▄█ ▀░░▀ ▀░░▀ ▀░▀"
//        };

//        Console.ForegroundColor = ConsoleColor.DarkGreen;
//        Console.WriteLine(bannerLines[0]);
//        Console.ForegroundColor = ConsoleColor.White;
//        Console.WriteLine(bannerLines[1]);
//        Console.ForegroundColor = ConsoleColor.DarkYellow;
//        Console.WriteLine(bannerLines[2]);
//        Console.ForegroundColor = ConsoleColor.White;
//    }

//    static void MostrarMenu()
//    {
//        Console.WriteLine("\nEscolha uma opção:");
//        Console.WriteLine();
//        Console.WriteLine("1. Saldo");
//        Console.WriteLine("2. Depositar valores");
//        Console.WriteLine("3. Sacar valores");
//        Console.WriteLine("4. Extrato");
//        Console.WriteLine("5. Depositar e aplicar na poupança");
//        Console.WriteLine();
//        Console.Write("Digite o número da opção desejada: ");
//    }

//    static void ExecutarEscolha(int escolha)
//    {
//        switch (escolha)
//        {
//            case 1:
//                Saldo();
//                break;
//            case 2:
//                Depositar();
//                break;
//            case 3:
//                Sacar();
//                break;
//            case 4:
//                Extrato();
//                break;
//            case 5:
//                DepositarEAplicarPoupanca();
//                break;

//            default:
//                Console.WriteLine("Opção inválida. Tente novamente.");
//                break;
//        }
//    }

//    public delegate void ConsultaBancaria();
//    public delegate void TransacaoBancaria(decimal amount);

//    static CaixaEletronico caixaEletronico = new CaixaEletronico();
//    static TransacaoBancaria transacao;
//    static ConsultaBancaria consulta;

//    private static void Saldo()
//    {
//        consulta = caixaEletronico.Saldo;
//        consulta();
//    }

//    private static void Depositar()
//    {
//        transacao = delegate (decimal valor)
//        {
//            caixaEletronico.Depositar(valor);
//            caixaEletronico.Saldo();
//        };

//        transacao(100);
//        transacao(40);
//        transacao(25);
//    }

//    private static void Sacar()
//    {
//        transacao = delegate (decimal valor)
//        {
//            caixaEletronico.Sacar(valor);
//            caixaEletronico.Saldo();
//        };

//        transacao(50);
//        transacao(20);
//    }

//    private static void Extrato()
//    {
//        consulta = caixaEletronico.Extrato;
//        consulta();
//    }

//    private static void DepositarEAplicarPoupanca()
//    {
//        //transacao = delegate (decimal valor)
//        //{
//        //    caixaEletronico.Depositar(valor);
//        //    caixaEletronico.AplicarPoupanca(valor);
//        //};
//        //transacao(50);

//        TransacaoBancaria depositar = caixaEletronico.Depositar;
//        TransacaoBancaria aplicar = caixaEletronico.AplicarPoupanca;
//        TransacaoBancaria saldo = delegate (decimal valor)
//        {
//            caixaEletronico.Saldo();
//        };

//        TransacaoBancaria depositarAplicarSaldo = depositar + aplicar + saldo;
//        //depositarAplicarSaldo(50);

//        //TransacaoBancaria aplicarSaldo = aplicar + saldo;
//        TransacaoBancaria aplicarSaldo = depositarAplicarSaldo - depositar;

//        aplicarSaldo(50);
//    }
//}