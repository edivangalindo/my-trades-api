using System;
using MyTrades.Domain.TradeContext.Enum;
using MyTrades.Domain.TradeContext.ValueObjects;

namespace MyTrades.Domain.Commands.UserCommands.Inputs
{
    public class OpenOperationCommand
    {
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

        public OpenOperationCommand(Guid user)
        {
            User = user;
        }
    }

}