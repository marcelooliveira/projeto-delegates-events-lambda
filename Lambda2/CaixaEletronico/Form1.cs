using System.Drawing;

namespace CaixaEletronico
{
    public partial class Form1 : Form
    {
        private readonly ContaCorrente contaCorrente;
        private string valorAtual = "10";

        public Form1()
        {
            InitializeComponent();
            contaCorrente = new ContaCorrente();
            contaCorrente.DepositoEvent += ContaCorrente_DepositoEvent;
            contaCorrente.SaqueEvent += ContaCorrente_SaqueEvent;
            contaCorrente.SaldoInsuficienteEvent += ContaCorrente_SaldoInsuficienteEvent;

            lblSaldo.Text = contaCorrente.ConsultarSaldo().ToString("C");
            txtValor.Text = valorAtual;
            //btnSaldo.Click += btnConsultarSaldo_Click;
            btnSaldo.Click += (sender, e) =>
            {
                MessageBox.Show($"Saldo atual: {Saldo:C}");
            };
        }

        private void ContaCorrente_SaldoInsuficienteEvent(object sender, TransacaoEventArgs e)
        {
            MessageBox.Show("Saldo insuficiente!");
        }

        private void ContaCorrente_SaqueEvent(object sender, TransacaoEventArgs e)
        {
            MessageBox.Show($"Saque de {e.ValorTransacao:C} realizado com sucesso!");
            valorAtual = "";
            txtValor.Text = valorAtual;
            lblSaldo.Text = e.Saldo.ToString("C");
        }

        private void ContaCorrente_DepositoEvent(object sender, TransacaoEventArgs e)
        {
            MessageBox.Show($"Depósito de {e.ValorTransacao:C} realizado com sucesso!");
            valorAtual = "";
            txtValor.Text = valorAtual;
            lblSaldo.Text = e.Saldo.ToString("C");
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
                MessageBox.Show("Valor inválido!");
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
                MessageBox.Show("Valor inválido!");
            }
        }

        private void btnConsultarSaldo_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Saldo atual: {Saldo:C}");
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            valorAtual = txtValor.Text;
        }

        private decimal Saldo
        {
            get
            {
                decimal saldo = contaCorrente.ConsultarSaldo();
                lblSaldo.Text = saldo.ToString("C");
                return saldo;
            }
        }
    }
}