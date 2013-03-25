using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketDataDissemination.Infrastructure
{
    [Serializable]
    public abstract class ExchangeBase
    {
        protected ExchangeBase(long sequence, string contract, long level, double price, long quantity, LimitOrderSide side, MessageType type )
        {
            this.Contract = contract;
            this.Sequence = sequence;
            this.Level = level;
            this.Price = price;
            this.Quantity = quantity;
            this.Side = side;
            this.Type = type;
        }
        public long Sequence { get; set; }

        public string Contract { get; set; }

        public long Level { get; set; }

        public double Price { get; set; }

        public long Quantity { get; set; }

        public LimitOrderSide Side { get; set; }

        public MessageType Type { get; set; }

    }

    [Serializable]
    public enum LimitOrderSide
    {
        Buy,
        Sell
    }

    [Serializable]
    public enum MessageType
    {
        NewLevel,
        DeleteLevel,
        UpdateLevel
    }
}
