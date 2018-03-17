using MyTrades.Domain.SharedContext.ValueObjects;

namespace MyTrades.Domain.TradeContext.Entities
{
    public class User
    {
        public User(
            Name name,
            Email email,
            Phone phoneNumber
        )
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Phone PhoneNumber { get; set; }
        
        public override string ToString()
        {
            return Name.ToString();
        }

    }
}