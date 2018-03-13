using System;
using System.Collections.Generic;
using MyTrades.Domain.Enum;
using MyTrades.Domain.ValueObjects;

namespace MyTrades.Domain.Entities
{
    public class Operation
    {
        public Operation(
            Pair pair, 
            DateTime initialDate,
            DateTime finalDate,
            Amount amount,
            decimal entryPoint,
            decimal exitPoint,
            double percentageResult,
            double riskMAnagement,
            decimal financialFeedback,
            EStatus status
        )
        {
            Pair = pair;
            InitialDate = initialDate;
            FinalDate = finalDate;
            Amount = amount;
            EntryPoint = entryPoint;
            ExitPoint = exitPoint;
            PercentageResult = percentageResult;
            RiskManagement = riskMAnagement;
            FinancialFeedback = financialFeedback;
            Status = status;
        }
        public string ID { get; private set; }
        public Pair Pair { get; private set; }
        public DateTime InitialDate { get; private set; }
        public DateTime FinalDate { get; private set; }
        public Amount Amount { get; private set; }
        public decimal EntryPoint { get; private set; }
        public decimal ExitPoint { get; private set; }
        public double PercentageResult { get; private set; }
        public double RiskManagement { get; private set; }
        public decimal FinancialFeedback { get; private set; }
        public EStatus Status { get; private set; }

        public void startOperation()
        {
            // Gera número da operação
            ID = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();

            // Abre uma operação
            Status = EStatus.Open;
            // Validar
        }
        public void finishOperation()
        {
            // Fecha uma operação
            Status = EStatus.Closed;

            // Calculate gains or losses
            var balance = new Balance();
            balance.updateBalance(calculateFinancialFeedback(Amount.CryptoAmount));
        }
        
        // Calcular ganhos/perdas
        public decimal calculateFinancialFeedback(decimal cryptoAmount)
        {
            return (cryptoAmount * ExitPoint) - (cryptoAmount * EntryPoint);
        }
    }
}