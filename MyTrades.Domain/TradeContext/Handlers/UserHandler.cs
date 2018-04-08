using System;
using Flunt.Notifications;
using MyTrades.Domain.Commands.UserCommands.Inputs;
using MyTrades.Domain.Commands.UserCommands.Outputs;
using MyTrades.Domain.SharedContext.ValueObjects;
using MyTrades.Domain.TradeContext.Entities;
using MyTrades.Shared.Commands;

namespace MyTrades.Domain.TradeContext.Handlers
{
    public class UserHandler : Notifiable, ICommandHandler<CreateUserCommand>, ICommandHandler<OpenOperationCommand>
    {
        public ICommandResult Handle(CreateUserCommand command)
        {
            // Verificar se o e-mail existe no banco

            // Criar os VO's
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var phone = new Phone(command.PhoneNumber);
            
            // Criar a entidade
            var user = new User(name, email, phone);

            // Validar entidades e VO's
            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(phone.Notifications);

            // Persistir o user
            // Retornar o resultado para tela

            return new CreateUserCommandResult(Guid.NewGuid(), name.ToString(), email.Address);

        }

        public ICommandResult Handle(OpenOperationCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
