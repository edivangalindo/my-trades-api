using System;
using MyTrades.Shared.Commands;

namespace MyTrades.Domain.Commands.UserCommands.Outputs
{
    public class CreateUserCommandResult : ICommandResult
    {
        public CreateUserCommandResult(){}
        public CreateUserCommandResult(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
