﻿namespace CaixaEletronico
{
    public interface IContaCorrente
    {
        void Depositar(decimal valor);
        void Sacar(decimal valor);
        Task<decimal> ConsultarSaldo();
    }
}
