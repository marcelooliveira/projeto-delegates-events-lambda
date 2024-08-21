public class Program
{
    public static void Main(string[] args)
    {
        ICaixaEletronico atm = new CaixaEletronico();

        TransacaoBancaria transacao;
        ConsultaBancaria consulta;

        consulta = atm.VerificarSaldo;
        consulta();

        transacao = atm.Depositar;
        transacao(100);
        transacao(40);
        transacao(25);

        transacao = atm.Sacar;
        transacao(50);
        transacao(20);

        // Assinando o evento
        //atm.AssinarSaldoInsuficiente();
        atm.OnSaldoInsuficiente += Atm_OnSaldoInsuficiente; ;
        transacao(500);

        // Cancelando a assinatura do evento
        //atm.CancelarAssinatura();
        atm.OnSaldoInsuficiente -= Atm_OnSaldoInsuficiente;
        transacao(500);

        consulta = atm.Extrato;
        consulta();

        Console.WriteLine("Multicast delegate");
        Console.WriteLine("==================");

        ConsultaBancaria saldo, extrato, multicastDelegate, outroMulticast;
        saldo = atm.VerificarSaldo;
        extrato = atm.Extrato;
        multicastDelegate = saldo + extrato;
        multicastDelegate();

        Console.WriteLine("Multicast sem o saldo");
        Console.WriteLine("=====================");

        outroMulticast = multicastDelegate - saldo;
        outroMulticast();
    }

    //private static void Atm_OnSaldoInsuficiente(object sender, EventArgs e)
    //{
    //    Console.WriteLine("Saldo insuficiente. Contate a central de atendimento do banco ByteBank para solicitar um limite maior no crédito para emergências.");
    //}

    private static void Atm_OnSaldoInsuficiente(object sender, SaldoInsuficienteEventArgs e)
    {
        Console.WriteLine($"Saldo insuficiente ({e.Saldo:C}) para o valor do saque ({e.Saque:C}). Contate a central de atendimento do banco ByteBank para solicitar um limite maior no crédito para emergências.");
    }

}