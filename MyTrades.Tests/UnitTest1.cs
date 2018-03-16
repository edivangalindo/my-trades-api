using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrades.Domain.Enum;
using MyTrades.Domain.Entities;
using MyTrades.Domain.ValueObjects;

namespace MyTrades.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var amount = new Amount(1);
            var pair = new Pair(EAssets.USD, EAssets.BTC);
            var operation = new Operation();

            operation.OpenOperation(
                pair,
                EType.Long,
                12,
                EModality.DayTrade,
                amount,
                9500,
                11000,
                8500,
                10400
            );

            var validate = operation.Valid;

            // operation.closeOperation(10800);
        }
    }
}
