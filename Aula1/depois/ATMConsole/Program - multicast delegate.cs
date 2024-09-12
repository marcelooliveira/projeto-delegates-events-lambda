//public class Program
//{
//    public static void Main(string[] args)
//    {
//        CaixaEletronico atm = new CaixaEletronico();

//        TransacaoBancaria transacao;
//        ConsultaBancaria consulta;

//        consulta = atm.VerificarSaldo;
//        consulta();

//        transacao = atm.Depositar;
//        transacao(100);
//        transacao(40);
//        transacao(25);

//        transacao = atm.Sacar;
//        transacao(50);
//        transacao(20);

//        consulta = atm.Extrato;
//        consulta();

//        Console.WriteLine("Multicast delegate");
//        Console.WriteLine("==================");

//        ConsultaBancaria saldo, extrato, multicastDelegate, outroMulticast;
//        saldo = atm.VerificarSaldo;
//        extrato = atm.Extrato;
//        multicastDelegate = saldo + extrato;
//        multicastDelegate();

//        Console.WriteLine("Multicast sem o saldo");
//        Console.WriteLine("=====================");

//        outroMulticast = multicastDelegate - saldo;
//        outroMulticast();
//    }
//}