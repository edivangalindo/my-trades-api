using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrades.Domain.SharedContext.ValueObjects;

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
            _nameInvalid = new Name("Ed", "de Barros Galindo");
        }

        [TestMethod]
        public void Deve_Retornar_Nome_Invalido()
        {
            Assert.AreEqual(true, _nameInvalid.Invalid);
        }

        public void Deve_Retornar_Nome_Valido()
        {
            Assert.AreEqual(true, _nameValid.Valid);
        }
    }
}