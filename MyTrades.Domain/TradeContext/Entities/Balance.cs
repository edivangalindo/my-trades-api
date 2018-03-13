using System;

namespace MyTrades.Domain.Entities
{
    public class Balance
    {
        public Balance()
        {
        }
        public decimal InitialInvestment { get; private set; }
        public decimal CurrentBalance { get; private set; }

        public void updateBalance(decimal amount)
        {
            bool isProfit = amount > 0 ? true : false;
            
            if (isProfit)
                CurrentBalance += amount;
            else
                CurrentBalance -= amount;
        }

    }
}