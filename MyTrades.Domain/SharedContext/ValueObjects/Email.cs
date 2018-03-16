using System;

namespace MyTrades.Domain.ValueObjects
{
    public class Email
    {
        public Email (string address)
        {
            Address = address;

            // Validar se o email é valido
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}