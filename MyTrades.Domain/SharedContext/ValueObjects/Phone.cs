using Flunt.Notifications;
using Flunt.Validations;
using System.Text.RegularExpressions;

namespace MyTrades.Domain.SharedContext.ValueObjects
{
    public class Phone : Notifiable
    {
        public Phone(string number)
        {
            Number = number;

            AddNotifications(new Contract()
            .Requires()
            .IsTrue(Validate(Number)
            , "Phone"
            , "Número de celular inválido."
            ));
        }

        public string Number { get; set; }
        public bool Validate(string number)
        {
            string pattern = @"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$";

            bool validation = Regex.IsMatch(number, pattern) ? true : false;

            return validation;
        }
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}