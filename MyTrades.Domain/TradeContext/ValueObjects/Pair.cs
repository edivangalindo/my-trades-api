using System;
using MyTrades.Domain.Enum;

namespace MyTrades.Domain.ValueObjects
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
