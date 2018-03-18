namespace MyTrades.Domain.TradeContext.ValueObjects
{
    public class Quantity
    {
        public Quantity (decimal quantityCrypto)
        {
            QuantityCrypto = quantityCrypto;
        }
        public decimal QuantityCrypto { get; private set; }
        public decimal QuantityDollar { get; private set; }
        public decimal QuantityReal { get; private set; }

        public void CalculateQuantityDollar()
        {
            // QuantityCrypto X Cotação da moeda
        }
        public void CalculateQuantityReal()
        {
            // QuantityCrypto X Cotação da moeda X Cotação do dólar
        }

        public override string ToString()
        {
            return $"{QuantityCrypto}";
        }
    }
}