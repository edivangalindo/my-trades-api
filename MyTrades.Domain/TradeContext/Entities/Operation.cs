using Flunt.Notifications;
using MyTrades.Domain.Enum;
using MyTrades.Domain.ValueObjects;
using System;

namespace MyTrades.Domain.Entities
{
    public class Operation : Notifiable
    {
        public Operation()
        {
            InitialDate = DateTime.Now;
        }

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
            double riskManagement,
            EModality modality,
            Amount amount,
            decimal entryPoint,
            decimal target,
            decimal stop,
            decimal partial = 0
        )
        {
            IdOperation = Guid.NewGuid().ToString();
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

            if (Amount.CryptoAmount <= 0)
                AddNotification("InvalidAmount", "O montante precisa ser maior que 0.");

            if (RiskManagement > 100 || RiskManagement < 0)
                AddNotification("InvalidRisk", "O G.R. deve ser maior que 0 e menor que 100.");
        }
        public void CloseOperation(string idOperation, decimal exitPoint)
        {
            IdOperation = idOperation;

            // Recuperar operação do banco

            Status = EStatus.Closed;
            FinalDate = DateTime.Now;

            ExitPoint = exitPoint;

            FinancialFeedback = CalculateFinancialFeedback(Amount.CryptoAmount);
            PercentageResult = CalculatePercentualResult(EntryPoint, ExitPoint);

            // Atualizar o saldo
            var balance = new Balance();
            balance.UpdateBalance(FinancialFeedback);

            // Adicionar validações
            if (ExitPoint <= 0)
                AddNotification("InvalidExitPoint", "O ponto de saída não pode ser inferior ou igual a 0.");
        }

        // Edit operation
        public void UpdateOperation(string idOperation)
        {
            IdOperation = idOperation;

            // Recuperar operação do banco
        }

        // Delete operation
        public void DeleteOperation(string idOperation)
        {
            IdOperation = idOperation;
            
            // Recuperar operação do banco
        }

        public decimal CalculateFinancialFeedback(decimal cryptoAmount) => (cryptoAmount * ExitPoint) - (cryptoAmount * EntryPoint);
        public double CalculatePercentualResult(decimal entryPoint, decimal exitPoint) => Convert.ToDouble((exitPoint - entryPoint) / entryPoint);
    }
}