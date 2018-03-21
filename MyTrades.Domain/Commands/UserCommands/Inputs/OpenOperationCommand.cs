using System;
using Flunt.Notifications;
using Flunt.Validations;
using MyTrades.Domain.TradeContext.Enum;
using MyTrades.Domain.TradeContext.ValueObjects;
using MyTrades.Shared.Commands;

namespace MyTrades.Domain.Commands.UserCommands.Inputs
{
    public class OpenOperationCommand : Notifiable, ICommand
    {
        public OpenOperationCommand(Guid user)
        {
            User = user;
        }

        public Guid User { get; set; }
        public Pair Pair { get; set; }
        public EType Type { get; set; }
        public DateTime InitialDate { get; set; }
        public decimal EntryPoint { get; set; }
        public decimal Partial { get; set; }
        public decimal Target { get; set; }
        public decimal Stop { get; set; }
        public double RiskManagement { get; set; }
        public EModality Modality { get; set; }
        public Quantity Quantity { get; set; }

        bool ICommand.Valid()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasLen(User.ToString(), 36, "InvalidUser", "Identificador do usuário inválido.")
                .IsLowerOrEqualsThan(EntryPoint, 0, "InvalidEntryPoint", "O valor da 'entrada' não pode ser igual ou inferior a zero.")
                .IsLowerOrEqualsThan(Target, 0, "InvalidTarget", "O valor do 'alvo' não pode ser igual ou inferior a zero.")
                .IsLowerOrEqualsThan(Stop, 0, "InvalidStop", "O valor do 'stop' não pode ser igual ou inferior a zero.")
                .IsLowerOrEqualsThan(RiskManagement, 0, "InvalidRiskManagement", "O percentual do 'gerenciamento de risco' não pode ser igual ou inferior a zero.")
                .IsLowerOrEqualsThan(Quantity.QuantityCrypto, 0, "InvalidQuantity", "A quantidade não pode ser igual ou inferior a zero.")
            );
            return Valid;
        }
    }
}