using System;
using System.Collections.Generic;
using MyTrades.Domain.Enum;
using MyTrades.Domain.ValueObjects;

namespace MyTrades.Domain.TradeContext.Entities
{
    public class Operation
    {
        public Operation()
        {
            InitialDate = DateTime.Now;
        }

        public string NumberOperation { get; private set; }
        public DateTime InitialDate { get; private set; }
        public Pair Pair { get; private set; }
        public EType Type { get; private set; }
        public decimal EntryPoint { get; private set; }
        public decimal Partial { get; private set; }
        public decimal Target { get; private set; }
        public decimal ExitPoint { get; private set; }
        public decimal Stop { get; private set; }
        public double RiskManagement { get; private set; }
        public EModality Modality { get; private set; }
        public Amount Amount { get; private set; }
        public DateTime FinalDate { get; private set; }
        public double PercentageResult { get; private set; }
        public decimal FinancialFeedback { get; private set; }
        public EStatus Status { get; private set; }

        public void startOperation(
            Pair pair,
            EType type,
            double riskManagement,
            EModality modality,
            Amount amount,
            decimal entryPoint,
            decimal target,
            decimal stop,
            decimal partial = 0
        )
        {
            NumberOperation = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            Status = EStatus.Open;

            Pair = pair;
            Type = type;
            RiskManagement = riskManagement;
            Modality = modality;
            Amount = amount;
            EntryPoint = entryPoint;
            Target = target;
            Stop = stop;
            Partial = partial;
        }
        public void finishOperation(decimal exitPoint)
        {
            Status = EStatus.Closed;
            FinalDate = DateTime.Now;

            ExitPoint = exitPoint;

            FinancialFeedback = calculateFinancialFeedback(Amount.CryptoAmount);
            PercentageResult = calculatePercentualResult(EntryPoint, ExitPoint);

            // Atualizar o saldo
            var balance = new Balance();
            balance.updateBalance(FinancialFeedback);
        }
        public decimal calculateFinancialFeedback(decimal cryptoAmount) => (cryptoAmount * ExitPoint) - (cryptoAmount * EntryPoint);
        public double calculatePercentualResult(decimal entryPoint, decimal exitPoint) => Convert.ToDouble((exitPoint - entryPoint) / entryPoint);
    }
}