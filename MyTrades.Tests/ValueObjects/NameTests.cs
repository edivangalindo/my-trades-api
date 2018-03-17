using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrades.Domain.ValueObjects;

namespace MyTrades.Tests
{
    [TestClass]
    public class NameTests
    {
        private Name _nameValid { get; set; }
        private Name _nameInvalid { get; set; }

        public NameTests()
        {
            _nameValid = new Name("Edivan", "De Barros Galindo");
            _nameInvalid = new Name("Edivan2", "_de Barros Galindo");
        }

        [TestMethod]
        public void Deve_Retornar_Notificacoes_Nome_E_Sobrenome_Invalidos()
        {
            Assert.AreEqual(2, _nameInvalid.Notifications.Count);
        }

        public void Deve_Retornar_Nome_Valido()
        {
            Assert.AreEqual(true, _nameValid.Valid);
        }
    }
}