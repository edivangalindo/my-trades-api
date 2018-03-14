using System;
using FluentValidator;
using MyTrades.Domain.Enum;

namespace MyTrades.Domain.ValueObjects
{
    public class Amount : Notifiable
    {
        public Amount (decimal cryptoAmount)
        {
            CryptoAmount = cryptoAmount;
        }
        public decimal CryptoAmount { get; private set; }
        public decimal DollarAmount { get; private set; }
        public decimal RealAmount { get; private set; }

        public void calculateDollarAmount()
        {
            // CryptoAmount X Cotação da moeda
        }
        public void calculateRealAmount()
        {
            // CryptoAmount X Cotação da moeda X Cotação do dólar
        }
    }
}