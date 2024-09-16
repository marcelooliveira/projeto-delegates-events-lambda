﻿using System.Text;

namespace ByteBank.CaixaEletronico
{
    public class CaixaEletronico : ICaixaEletronico
    {
        private const int LarguraExtrato = 65;
        private decimal saldo;
        private List<ItemExtrato> itensExtrato = new();

        public event SaldoInsuficienteEventHandler OnSaldoInsuficiente;
        public event DepositoEventHandler OnDeposito;
        public event SaqueEventHandler OnSaque;

        public CaixaEletronico()
        {
            saldo = 100;
            var item = new ItemExtrato
            {
                Data = DateTime.Now.AddDays(-2),
                Descricao = "Saldo Inicial",
                Valor = saldo,
                Sinal = SinalOperacao.Credito
            };
            itensExtrato.Add(item);
        }

        public decimal Saldo()
        {
            return saldo;
        }

        public string Extrato()
        {
            var stringBuilder = new StringBuilder();
            ImprimirCabecalho(stringBuilder);

            foreach (var item in itensExtrato)
            {
                ImprimirItemExtrato(stringBuilder, item);
            }

            ImprimirSaldo(stringBuilder);
            return stringBuilder.ToString();
        }

        public void Depositar(decimal valor)
        {
            saldo += valor;
            var item = new ItemExtrato
            {
                Data = DateTime.Now,
                Descricao = "Depósito",
                Valor = valor,
                Sinal = SinalOperacao.Credito
            };

            itensExtrato.Add(item);
            OnDeposito?.Invoke(this, new TransacaoEventArgs(saldo, valor));
        }

        public void Sacar(decimal valor)
        {
            if (valor > saldo)
            {
                OnSaldoInsuficiente?.Invoke(this, new TransacaoEventArgs(saldo, valor));
            }
            else
            {
                saldo -= valor;
                var item = new ItemExtrato
                {
                    Data = DateTime.Now,
                    Descricao = "Saque",
                    Valor = valor,
                    Sinal = SinalOperacao.Debito
                };

                itensExtrato.Add(item);
                OnSaque?.Invoke(this, new TransacaoEventArgs(saldo, valor));
            }
        }

        private void ImprimirCabecalho(StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine(new string('=', LarguraExtrato));
            stringBuilder.AppendLine(string.Format("{0,-20} {1,-25} {2,18}", "Data/Hora", "Descrição", "Valor (R$)"));
            stringBuilder.AppendLine(new string('=', LarguraExtrato));
        }

        private void ImprimirItemExtrato(StringBuilder stringBuilder, ItemExtrato item)
        {
            stringBuilder.AppendLine(item.ToString());
        }

        private void ImprimirSaldo(StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine(new string('=', LarguraExtrato));
            string valor = saldo.ToString("N2").PadLeft(18);
            stringBuilder.AppendLine(string.Format("{0,-20} {1,-25} {2,18}", string.Empty, "Saldo", valor));
            stringBuilder.AppendLine(new string('=', LarguraExtrato));
        }
    }

    public delegate void SaldoEventHandler(object sender, SaldoEventArgs e);
    public delegate void DepositoEventHandler(object sender, TransacaoEventArgs e);
    public delegate void SaqueEventHandler(object sender, TransacaoEventArgs e);
    public delegate void SaldoInsuficienteEventHandler(object sender, TransacaoEventArgs e);
}

class ItemExtrato
{
    public DateTime Data { get; set; }
    public string Descricao { get; set; }
    public SinalOperacao Sinal { get; set; }
    public decimal Valor { get; set; }

    public override string ToString()
    {
        string data = Data.ToString("dd/MM/yyyy HH:mm:ss");
        string descricao = Descricao.Length > 50 ? Descricao.Substring(0, 50) : Descricao;
        string valor = (Valor * (int)Sinal).ToString("N2").PadLeft(18);

        return string.Format("{0,-20} {1,-25} {2}", data, descricao, valor);
    }
}

enum SinalOperacao
{
    Credito = 1,
    Debito = -1
}
