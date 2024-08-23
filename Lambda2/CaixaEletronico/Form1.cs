using System.Drawing;

namespace CaixaEletronico
{
    public partial class Form1 : Form
    {
        private readonly ContaCorrente contaCorrente;
        private string valorAtual = "10";
        private decimal saldo = 0;

        public Form1()
        {
            InitializeComponent();
            contaCorrente = new ContaCorrente();
            contaCorrente.DepositoEvent += ContaCorrente_DepositoEvent;
            contaCorrente.SaqueEvent += ContaCorrente_SaqueEvent;
            contaCorrente.SaldoInsuficienteEvent += ContaCorrente_SaldoInsuficienteEvent;
            txtValor.Text = valorAtual;

            //btnSaldo.Click += btnConsultarSaldo_Click;
            btnSaldo.Click += async (sender, e) =>
            {
                btnDepositar.Enabled = btnSacar.Enabled = true;
                var saldo = await contaCorrente.ConsultarSaldo();
                WriteToConsole($"Saldo atual: {saldo:C}");
            };
        }

        private void ContaCorrente_SaldoInsuficienteEvent(object sender, TransacaoEventArgs e)
        {
            WriteToConsole("Saldo insuficiente!");
        }

        private void ContaCorrente_SaqueEvent(object sender, TransacaoEventArgs e)
        {
            WriteToConsole($"Saque de {e.ValorTransacao:C} realizado com sucesso!");
            valorAtual = "";
            txtValor.Text = valorAtual;
        }

        private void ContaCorrente_DepositoEvent(object sender, TransacaoEventArgs e)
        {
            WriteToConsole($"Depósito de {e.ValorTransacao:C} realizado com sucesso!");
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
            WriteToConsole($"Saldo atual: {saldo:C}");
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            valorAtual = txtValor.Text;
        }

        private void WriteToConsole(string mensagem)
        {
            txtConsole.Text += mensagem;
            txtConsole.Text += "\r\n";
            txtConsole.SelectionStart = txtConsole.TextLength;
            txtConsole.ScrollToCaret();
        }
    }
}