using System;
using MyTrades.Domain.TradeContext.Enum;

namespace MyTrades.Domain.TradeContext.ValueObjects
{
    public class Pair
    {
        public Pair(EAssets pairMother, EAssets pairSon)
        {
            PairMother = pairMother;
            PairSon = pairSon;
        }

        public EAssets PairMother { get; private set; }
        public EAssets PairSon { get; private set; }

        public override string ToString()
        {
            return $"{PairMother}, {PairSon}";
        }
    }
}
