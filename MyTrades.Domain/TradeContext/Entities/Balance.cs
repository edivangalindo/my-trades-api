namespace MyTrades.Domain.TradeContext.Entities
{
    public class Balance
    {
        public Balance()
        {

        }

        public Balance(decimal initialInvestment)
        {
            CurrentBalance = initialInvestment;
        }

        public decimal InitialInvestment { get; private set; }
        public decimal CurrentBalance { get; private set; }

        public decimal GetCurrentBalance()
        {
            // Recuperar o balanço no banco e atribuir ao CurrentBalance

            return CurrentBalance;
        }

        public void UpdateBalance(decimal Quantity)
        {
            bool isProfit = Quantity > 0 ? true : false;
            
            if (isProfit)
                CurrentBalance += Quantity;
            else
                CurrentBalance -= Quantity;
        }

        public override string ToString()
        {
            return CurrentBalance.ToString();
        }
    }
}