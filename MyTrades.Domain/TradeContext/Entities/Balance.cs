using System;

namespace MyTrades.Domain.Entities
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

        public void updateBalance(decimal amount)
        {
            bool isProfit = amount > 0 ? true : false;
            
            if (isProfit)
                CurrentBalance += amount;
            else
                CurrentBalance -= amount;
        }

        public override string ToString()
        {
            return CurrentBalance.ToString();
        }
    }
}