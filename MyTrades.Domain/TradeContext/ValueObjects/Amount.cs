using System;
using MyTrades.Domain.TradeContext.Enum;

namespace MyTrades.Domain.TradeContext.ValueObjects
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
    }
}