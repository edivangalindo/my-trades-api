using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrades.Domain.Entities;
using MyTrades.Domain.Enum;
using MyTrades.Domain.ValueObjects;

namespace MyTrades.Tests
{
    [TestClass]
    public class OperationTests
    {
        private Operation _validOperation { get; set; }
        private Operation _invalidOperation { get; set; }

        public OperationTests()
        {
            _validOperation = new Operation();
        }

        [TestMethod]
        public void Deve_Criar_Uma_Operacao_Quando_Valida()
        {
            var pair = new Pair(EAssets.USD, EAssets.BTC);
            var amount = new Amount(0.005m);

            _validOperation.OpenOperation(
                pair, 
                EType.Long, 
                25, 
                EModality.DayTrade, 
                amount, 
                8500.78m, 
                9807.80m, 
                7500m, 
                9300m
            );

            Assert.AreEqual(true, _validOperation.Valid);
        }

        [TestMethod]
        public void Deve_Atribuir_Status_Open_Ao_Abrir_Uma_Operacao()
        {
            Assert.Fail();
        }
        
        [TestMethod]
        public void Deve_Atribuir_Status_Canceled_Ao_Cancelar_Uma_Operacao()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Deve_Fechar_Uma_Operacao_Quando_Valida()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Deve_Atribuir_Status_Closed_Ao_Fechar_Uma_Operacao()
        {
            Assert.Fail();
        }
    }
}
