namespace ByteBank.CaixaEletronico
{
    public partial class Form1 : Form
    {
        private readonly Conta contaCorrente;
        private string valorAtual = "10";

        public Form1()
        {
            InitializeComponent();
            contaCorrente = new Conta();
            contaCorrente.DepositoEvent += ContaCorrente_DepositoEvent;
            contaCorrente.SaqueEvent += ContaCorrente_SaqueEvent;
            contaCorrente.SaldoInsuficienteEvent += ContaCorrente_SaldoInsuficienteEvent;
            txtValor.Text = valorAtual;

            btnSacar.Click += btnSacar_Click;

            btnDepositar.Click += btnDepositar_Click;

            btnSaldo.Click += btnConsultarSaldo_Click;
        }

        private void ContaCorrente_SaldoInsuficienteEvent(object sender, TransacaoEventArgs e)
        {
            WriteToConsole("Saldo insuficiente!");
        }

        private void ContaCorrente_SaqueEvent(object sender, TransacaoEventArgs e)
        {
            string mensagem = $"Saque de {e.ValorTransacao:C} realizado com sucesso!";
            WriteToConsole(mensagem);
            valorAtual = "";
            valorAtual = txtValor.Text = valorAtual;
        }

        private void ContaCorrente_DepositoEvent(object sender, TransacaoEventArgs e)
        {
            string mensagem = $"Depósito de {e.ValorTransacao:C} realizado com sucesso!";
            WriteToConsole(mensagem);
            valorAtual = "";
            txtValor.Text = valorAtual;
        }

        private void btnNumero_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            valorAtual += btn.Text;
            txtValor.Text = valorAtual;
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(valorAtual, out decimal valorSaque))
            {
                contaCorrente.Sacar(valorSaque);
            }
            else
            {
                WriteToConsole("Valor inválido!");
            }
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(valorAtual, out decimal valorDeposito))
            {
                contaCorrente.Depositar(valorDeposito);
            }
            else
            {
                WriteToConsole("Valor inválido!");
            }
        }

        private void btnConsultarSaldo_Click(object sender, EventArgs e)
        {
            decimal saldo = contaCorrente.ConsultarSaldo();
            WriteToConsole($"Saldo atual: {saldo:C}");
            btnSacar.Enabled = btnDepositar.Enabled = true;
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            valorAtual = txtValor.Text;
        }

        private void WriteToConsole(string mensagem)
        {
            txtConsole.Text += mensagem;
            txtConsole.Text += Environment.NewLine;
            txtConsole.SelectionStart = txtConsole.TextLength;
            txtConsole.ScrollToCaret();
        }
    }
}