using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrades.Domain.SharedContext.ValueObjects;

namespace MyTrades.Tests
{
    [TestClass]
    public class EmailTests
    {
        private Email _validEmail { get; set; }
        private Email _invalidEmail { get; set; }

        public EmailTests()
        {
            _validEmail = new Email("edivan.galindo@gmail.com");
            _invalidEmail = new Email("edivan.galindo@gmail");
        }

        [TestMethod]
        public void Deve_Retornar_Notificacao_Quando_O_Email_For_Invalido()
        {
            Assert.AreEqual(1, _invalidEmail.Notifications.Count);
        }

        [TestMethod]
        public void Deve_Retornar_Notificacao_Quando_O_Email_For_Valido()       
        {
            Assert.AreEqual(true, _validEmail.Valid);
        }
    }
}
