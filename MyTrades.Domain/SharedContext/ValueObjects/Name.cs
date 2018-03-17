using System;
using System.Text.RegularExpressions;
using Flunt.Notifications;
using Flunt.Validations;

namespace MyTrades.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
            .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caractéres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caractéres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caractéres")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caractéres")
            );
        }
     
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}