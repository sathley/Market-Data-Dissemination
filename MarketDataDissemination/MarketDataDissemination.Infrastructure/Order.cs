namespace MarketDataDissemination.Infrastructure
{
    public class Order
    {
        public Order(long quantity, double price, long level)
        {
            this.Level = level;
            this.Price = price;
            this.Quantity = quantity;
        }

        public long Quantity { get; set; }

        public double Price { get; set; }

        public long Level { get; set; }
    }
}