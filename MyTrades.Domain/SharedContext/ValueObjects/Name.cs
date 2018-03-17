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
            .IsTrue(Validate(FirstName), "FirstName", "Primeiro nome inválido.")
            .IsTrue(Validate(LastName), "LastName", "Último nome inválido.")
            );
        }

        public bool Validate (string name)
        {
            string pattern = @"^[A-Za-z]+[\s][A-Za-z]+[.][A-Za-z]+$";

            bool validation = Regex.IsMatch(name, pattern) ? true : false;

            return validation;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}