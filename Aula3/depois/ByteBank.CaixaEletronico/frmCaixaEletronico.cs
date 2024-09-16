namespace ByteBank.CaixaEletronico
{
    public partial class frmCaixaEletronico : Form
    {
        private readonly CaixaEletronico caixaEletronico;
        private string valorAtual = "10";

        public frmCaixaEletronico()
        {
            InitializeComponent();
            caixaEletronico = new CaixaEletronico();
            caixaEletronico.OnDeposito += ContaCorrente_DepositoEvent;
            caixaEletronico.OnSaque += ContaCorrente_SaqueEvent;
            caixaEletronico.OnSaldoInsuficiente += ContaCorrente_SaldoInsuficienteEvent;
            txtValor.Text = valorAtual;

            btnSacar.Click += BtnSacar_Click;

            btnDepositar.Click += BtnDepositar_Click;

            btnSaldo.Click += BtnSaldo_Click;

            btnExtrato.Click += BtnExtrato_Click;
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

        private void BtnNumero_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            valorAtual += btn.Name.Last();
            txtValor.Text = valorAtual;
        }

        private void BtnSacar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(valorAtual, out decimal valorSaque))
            {
                caixaEletronico.Sacar(valorSaque);
            }
            else
            {
                WriteToConsole("Valor inválido!");
            }
        }

        private void BtnDepositar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(valorAtual, out decimal valorDeposito))
            {
                caixaEletronico.Depositar(valorDeposito);
            }
            else
            {
                WriteToConsole("Valor inválido!");
            }
        }

        private void BtnSaldo_Click(object sender, EventArgs e)
        {
            decimal saldo = caixaEletronico.Saldo();
            WriteToConsole($"Saldo atual: {saldo:C}");
            btnSacar.Enabled = btnDepositar.Enabled = true;
        }

        private void BtnExtrato_Click(object? sender, EventArgs e)
        {
            string extrato = caixaEletronico.Extrato();
            WriteToConsole(extrato);
            btnSacar.Enabled = btnDepositar.Enabled = true;
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.Location = new Point(btn.Location.X + 4, btn.Location.Y + 4);
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.Location = new Point(btn.Location.X - 4, btn.Location.Y - 4);
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

        private void btnOperacao_MouseUp(object sender, EventArgs e)
        {
            txtValor.Focus();
        }
    }
}