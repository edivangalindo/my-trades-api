using System;

namespace MyTrades.Domain.SharedContext.ValueObjects
{
    public class Phone
    {
        public Phone (string number)
        {
            Number = number;

            // Aplicar validações
        }
        
        public string Number { get; set; }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}