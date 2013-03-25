using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketDataDissemination.Infrastructure
{
    public class LimitBook
    {
        public LimitBook(string contract)
        {
            this.Contract = contract;
            this.BuyOrders = new List<Order>();
            this.SellOrders = new List<Order>();
        }

        public string Contract { get; set; }
        
        public List<Order> BuyOrders { get; set; }

        public List<Order> SellOrders { get; set; }

        public void ProcessDeleteOrder(ExchangeAMd message)
        {
            if(message.Side == LimitOrderSide.Sell)
            {
                ProcessSellDeleteOrder(message.Level);
            }

            if(message.Side == LimitOrderSide.Buy)
            {
                ProcessBuyDeleteOrder(message.Level);
            }
        }

        private void ProcessSellDeleteOrder(long level)
        {
            lock(SellOrders)
            {
                var orderToDelete = SellOrders.Find(o => o.Level == level);
                if (orderToDelete != null)
                    SellOrders.Remove(orderToDelete);
            }
        }

        private void ProcessBuyDeleteOrder(long level)
        {
            lock (BuyOrders)
            {
                var orderToDelete = BuyOrders.Find(o => o.Level == level);
                if (orderToDelete != null)
                    BuyOrders.Remove(orderToDelete);
            }
        }

        public void ProcessModifyOrder(ExchangeAMd message)
        {
            if (message.Side == LimitOrderSide.Sell)
            {
                ProcessSellModifyOrder(message.Level, message.Price, message.Quantity);
            }

            if (message.Side == LimitOrderSide.Buy)
            {
                ProcessBuyModifyOrder(message.Level, message.Price, message.Quantity);
            }
        }

        private void ProcessBuyModifyOrder(long level, double price, long quantity)
        {
            lock (BuyOrders)
            {
                var orderToModify = BuyOrders.Find(o => o.Level == level);
                if (orderToModify != null)
                {
                    var index = BuyOrders.IndexOf(orderToModify);
                    BuyOrders[index].Price = price;
                    BuyOrders[index].Quantity = quantity;
                }
            }
        }

        private void ProcessSellModifyOrder(long level, double price, long quantity)
        {
            lock (SellOrders)
            {
                var orderToModify = SellOrders.Find(o => o.Level == level);
                if (orderToModify != null)
                {
                    var index = SellOrders.IndexOf(orderToModify);
                    SellOrders[index].Price = price;
                    SellOrders[index].Quantity = quantity;
                }
            }
        }

        public void ProcessNewOrder(ExchangeAMd message)
        {
            if (message.Side == LimitOrderSide.Sell)
            {
                ProcessSellAddOrder(message.Level, message.Price, message.Quantity);
            }

            if (message.Side == LimitOrderSide.Buy)
            {
                ProcessBuyAddOrder(message.Level, message.Price, message.Quantity);
            }
        }

        private void ProcessBuyAddOrder(long level, double price, long quantity)
        {
            var order = new Order(quantity, price, level);
            BuyOrders.Add(order);
        }

        private void ProcessSellAddOrder(long level, double price, long quantity)
        {
            var order = new Order(quantity,price,level);
            SellOrders.Add(order);
        }
        
    }
}
