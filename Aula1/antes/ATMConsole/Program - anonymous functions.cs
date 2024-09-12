//public class Program
//{
//    public static void Main(string[] args)
//    {
//        CaixaEletronico atm = new CaixaEletronico();

//        ConsultaBancaria consulta;
//        consulta = delegate
//        {
//            atm.VerificarSaldo();
//            Console.WriteLine("Saldo verificado com sucesso.");
//        };
//        consulta();

//        TransacaoBancaria transacao;
//        transacao = delegate (decimal amount)
//        {
//            atm.Depositar(amount);
//            atm.VerificarSaldo();
//            Console.WriteLine("Depósito efetuado com sucesso.");
//        };
//        transacao(100);
//        transacao(40);
//        transacao(25);

//        transacao = delegate (decimal amount)
//        {
//            atm.Sacar(amount);
//            atm.VerificarSaldo();
//            Console.WriteLine("Saque efetuado com sucesso.");
//        };
//        transacao(50);
//        transacao(20);

//        consulta = delegate
//        {
//            atm.Extrato();
//            Console.WriteLine("Extrato obtido com sucesso.");
//        };
//        consulta();
//    }
//}