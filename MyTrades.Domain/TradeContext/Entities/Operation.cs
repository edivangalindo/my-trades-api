using System;
using MyTrades.Domain.Enum;

namespace MyTrades.Domain.Entities
{
    public class Operation
    {
        public Operation ()
        {
            
        }
        public string Pair { get; private set; }
        public DateTime InitialDate { get; private set; }
        public DateTime FinalDate { get; private set; }
        public EAmount Amount { get; private set; }
        public decimal EntryPoint { get; private set; }
        public decimal ExitPoint { get; private set; }
        public double PercentageResult { get; private set; }
        public double RiskManagement { get; private set; }
        public decimal FinancialFeedback { get; private set; }
    }
}