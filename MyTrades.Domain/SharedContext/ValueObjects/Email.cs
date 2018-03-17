using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace MyTrades.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email (string address)
        {
            Address = address;

            AddNotifications(new Contract().Requires().IsEmail(Address, "Email", "Email inválido."));
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}