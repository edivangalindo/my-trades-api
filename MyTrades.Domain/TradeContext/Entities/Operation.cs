using Flunt.Notifications;
using MyTrades.Domain.TradeContext.Enum;
using MyTrades.Domain.TradeContext.ValueObjects;
using System;

namespace MyTrades.Domain.TradeContext.Entities
{
    public class Operation : Notifiable
    {
        public Operation(User user)
        {
            User = user;
        }

        public User User { get; private set; }  
        public string IdOperation { get; private set; }
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

        public void OpenOperation(
            Pair pair,
            EType type,
            DateTime initialDate,
            decimal entryPoint,
            decimal partial,
            decimal target,
            decimal stop,
            double riskManagement,
            EModality modality,
            Amount amount
        )
        {
            IdOperation = Guid.NewGuid().ToString();
            Status = EStatus.Open;

            Pair = pair;
            Type = type;
            InitialDate = initialDate;
            EntryPoint = entryPoint;
            Partial = partial;
            Target = target;
            Stop = stop;
            RiskManagement = riskManagement;
            Modality = modality;
            Amount = amount;

            if (Amount.CryptoAmount <= 0.00000000m)
                AddNotification("InvalidAmount", "O montante precisa ser maior que 0.00000000 (1 satoshi)");
            if (RiskManagement <= 0)
                AddNotification("InvalidRisk", "O G.R. não pode ser igual ou inferior a 0% do capital.");
            if (RiskManagement > 100)
                AddNotification("InvalidRisk", "O G.R. não pode ser superior a 100% do capital.");

        }

        public void CloseOperation(string idOperation, decimal exitPoint, DateTime finalDate)
        {
            Status = EStatus.Closed;

            IdOperation = idOperation;
            ExitPoint = exitPoint;
            FinalDate = finalDate;

            // Adicionar validações
            if (ExitPoint <= 0)
                AddNotification("InvalidExitPoint", "O ponto de saída não pode ser inferior ou igual a 0.");

            // Recuperar informações do banco

            // FinancialFeedback = CalculateFinancialFeedback(Amount.CryptoAmount);
            // PercentageResult = CalculatePercentualResult(EntryPoint, ExitPoint);

            // Atualizar o saldo
            // var balance = new Balance();
            // balance.UpdateBalance(FinancialFeedback);
        }

        public void UpdateOperation(string idOperation)
        {
            IdOperation = idOperation;

            // Recuperar operação do banco
        }

        public void CancelOperation(string idOperation)
        {
            IdOperation = idOperation;

            Status = EStatus.Canceled;
            FinalDate = DateTime.Now;
        }

        public decimal CalculateFinancialFeedback(decimal cryptoAmount) => (cryptoAmount * ExitPoint) - (cryptoAmount * EntryPoint);
        public double CalculatePercentualResult(decimal entryPoint, decimal exitPoint) => Convert.ToDouble((exitPoint - entryPoint) / entryPoint);
    }
}