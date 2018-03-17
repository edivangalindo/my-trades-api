using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrades.Domain.Entities;
using MyTrades.Domain.Enum;
using MyTrades.Domain.ValueObjects;

namespace MyTrades.Tests
{
    [TestClass]
    public class OperationTests
    {
        private Operation _operation { get; set; }
        private Pair _pair { get; set; }
        private Amount _amount { get; set; }

        public OperationTests()
        {
            _operation = new Operation();
            _pair = new Pair(EAssets.USD, EAssets.BTC);
            _amount = new Amount(0.005m);
        }

        [TestMethod]
        public void Deve_Criar_Uma_Operacao_Quando_Valida()
        {
            _operation.OpenOperation(
                _pair,
                EType.Long,
                DateTime.Now,
                8500m,
                9100m,
                9900m,
                7900m,
                25,
                EModality.DayTrade,
                _amount
            );

            Assert.AreEqual(true, _operation.Valid);
        }

        [TestMethod]
        public void Deve_Atribuir_Status_Open_Ao_Abrir_Uma_Operacao()
        {
            _operation.OpenOperation(
                _pair,
                EType.Long,
                DateTime.Now,
                8500m,
                9100m,
                9900m,
                7900m,
                25,
                EModality.DayTrade,
                _amount
            );

            Assert.AreEqual(_operation.Status, EStatus.Open);
        }

        [TestMethod]
        public void Deve_Atribuir_Status_Canceled_Ao_Cancelar_Uma_Operacao()
        {
            _operation.CancelOperation("b15gg-456gf-s655s-65gb");

            Assert.AreEqual(_operation.Status, EStatus.Canceled);
        }

        [TestMethod]
        public void Deve_Fechar_Uma_Operacao_Quando_Valida()
        {
            _operation.CloseOperation("b15gg-456gf-s655s-65gb", 9700m, DateTime.Now);

            Assert.AreEqual(true, _operation.Valid);
        }

        [TestMethod]
        public void Deve_Atribuir_Status_Closed_Ao_Fechar_Uma_Operacao()
        {
            _operation.CloseOperation("b15gg-456gf-s655s-65gb", 9700m, DateTime.Now);

            Assert.AreEqual(_operation.Status, EStatus.Closed);
        }
    }
}
