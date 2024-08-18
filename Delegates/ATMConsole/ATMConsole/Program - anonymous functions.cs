//public class Program
//{
//    public static void Main(string[] args)
//    {
//        CaixaEletronico atm = new CaixaEletronico();

//        ConsultaBancaria consulta;
//        consulta = delegate
//        {
//            atm.VerificarSaldo();
//        };
//        consulta();

//        TransacaoBancaria transacao;
//        transacao = delegate (decimal amount)
//        {
//            atm.Depositar(amount);
//        };
//        transacao(100);
//        transacao(40);
//        transacao(25);

//        transacao = delegate (decimal amount)
//        {
//            atm.Sacar(amount);
//        };
//        transacao(50);
//        transacao(20);

//        consulta = delegate
//        {
//            atm.Extrato();
//        };
//        consulta();
//    }
//}