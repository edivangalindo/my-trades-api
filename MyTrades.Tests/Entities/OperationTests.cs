using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrades.Domain.SharedContext.ValueObjects;
using MyTrades.Domain.TradeContext.Entities;
using MyTrades.Domain.TradeContext.Enum;
using MyTrades.Domain.TradeContext.ValueObjects;
using System;

namespace MyTrades.Tests.Entities
{
    [TestClass]
    public class OperationTests
    {
        private Name _name { get; set; }
        private Email _email { get; set; }
        private Phone _phone { get; set; }
        private User _user { get; set; }
        private Operation _operation { get; set; }
        private Pair _pair { get; set; }
        private Quantity _quantity { get; set; }

        public OperationTests()
        {
            _name = new Name("Edivan", "Galindo");
            _email = new Email("edivan.galindo@gmail.com");
            _phone = new Phone("966803654");

            _user = new User(_name, _email, _phone);

            _operation = new Operation(_user);
            _pair = new Pair(EAssets.USD, EAssets.BTC);
            _quantity = new Quantity(0.005m);
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
                _quantity
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
                _quantity
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
