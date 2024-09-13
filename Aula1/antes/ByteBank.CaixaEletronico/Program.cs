using System.Reflection;

internal class Program
{
    static CaixaEletronico atm = new CaixaEletronico();
    static TransacaoBancaria transacao;
    static ConsultaBancaria consulta;

    private static void Main(string[] args)
    {
        
        MostrarBanner();

        while (true)
        {
            MostrarMenu();

            if (int.TryParse(Console.ReadLine(), out int escolha))
            {
                ExecutarEscolha(escolha);
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }

        static void MostrarBanner()
        {
            Console.WriteLine(@"


    ____        __       ____              __      
   / __ )__  __/ /____  / __ )____ _____  / /__    
  / __  / / / / __/ _ \/ __  / __ `/ __ \/ //_/    
 / /_/ / /_/ / /_/  __/ /_/ / /_/ / / / / ,<       
/_____/\__, /\__/\___/_____/\__,_/_/ /_/_/|_|      
      /____/                                       
                                
        ");
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine();
            Console.WriteLine("1. Rodar operações");
            Console.WriteLine();
            Console.Write("Digite o número da opção desejada: ");
        }

        static void ExecutarEscolha(int escolha)
        {
            switch (escolha)
            {
                case 1:
                    RodarOperacoes();
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        static void RodarOperacoes()
        {
            consulta = atm.VerificarSaldo;
            consulta();

            transacao = atm.Depositar;
            transacao(100);
            transacao(40);
            transacao(25);

            transacao = atm.Sacar;
            transacao(50);
            transacao(20);

            consulta = atm.Extrato;
            consulta();
        }
    }
}