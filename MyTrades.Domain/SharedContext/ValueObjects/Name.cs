using System;

namespace MyTrades.Domain.SharedContext.ValueObjects
{
    public class Name
    {
        public Name()
        {
            
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}