using System;

namespace MyTrades.Domain.Commands.UserCommands.Inputs
{
    public class OpenOperationCommand
    {
        public Guid User { get; set; }

        public OpenOperationCommand(Guid user)
        {
            User = user;
        }
    }

}