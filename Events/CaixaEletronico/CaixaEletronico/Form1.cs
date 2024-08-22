namespace CaixaEletronico
{
    public partial class Form1 : Form
    {
        private decimal saldo = 1000; // Saldo inicial
        private string valorAtual = "";

        public Form1()
        {
            InitializeComponent();
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
                if (valorSaque > saldo)
                {
                    MessageBox.Show("Saldo insuficiente!");
                }
                else
                {
                    saldo -= valorSaque;
                    MessageBox.Show($"Saque de {valorSaque:C} realizado com sucesso!");
                    valorAtual = "";
                    txtValor.Text = valorAtual;
                }
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
                saldo += valorDeposito;
                MessageBox.Show($"Depósito de {valorDeposito:C} realizado com sucesso!");
                valorAtual = "";
                txtValor.Text = valorAtual;
            }
            else
            {
                MessageBox.Show("Valor inválido!");
            }
        }

        private void btnConsultarSaldo_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Saldo atual: {saldo:C}");
        }

    }
}