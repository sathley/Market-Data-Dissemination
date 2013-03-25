using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketDataDissemination.Infrastructure
{
    [Serializable]
    public class ExchangeAMd : ExchangeBase
    {
        public ExchangeAMd(long sequence, string contract, long level, double price, long quantity, LimitOrderSide side, MessageType type) : base(sequence, contract, level, price, quantity, side, type)
        {
        }


    }
}
