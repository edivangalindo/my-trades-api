using Flunt.Notifications;
using Flunt.Validations;
using MyTrades.Shared.Commands;

namespace MyTrades.Domain.Commands.UserCommands.Inputs
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        bool ICommand.Valid()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "InvalidFirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "InvalidFirstName", "O nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "InvalidLastName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 40, "InvalidLastName", "O sobrenome deve conter no máximo 40 caracteres")
                .IsEmail(Email, "InvalidEmail", "O e-mail informado não é válido.")
            );

            return Valid;
        }
    }
}
