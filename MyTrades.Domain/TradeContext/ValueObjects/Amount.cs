using System;
using MyTrades.Domain.Enum;

namespace MyTrades.Domain.ValueObjects
{
    public class Amount
    {
        public Amount (decimal cryptoAmount)
        {
            CryptoAmount = cryptoAmount;
        }
        public decimal CryptoAmount { get; private set; }
        public decimal DollarAmount { get; private set; }
        public decimal RealAmount { get; private set; }

        public void CalculateDollarAmount()
        {
            // CryptoAmount X Cotação da moeda
        }
        public void CalculateRealAmount()
        {
            // CryptoAmount X Cotação da moeda X Cotação do dólar
        }

        public override string ToString()
        {
            return $"{CryptoAmount}";
        }
    }
}