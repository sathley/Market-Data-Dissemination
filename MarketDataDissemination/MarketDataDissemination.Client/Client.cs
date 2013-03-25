using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using MarketDataDissemination.Infrastructure;

namespace MarketDataDissemination.Client
{
    public static class Client
    {
        public static List<LimitBook> Books = new List<LimitBook>();

        public static void ProcessOne()
        {
            var ip = Configuration.IPa;
            var port = Configuration.Porta;
            var remoteIP = new IPEndPoint(IPAddress.Parse(ip), port);
            Listen(remoteIP);
        }

        public static void ProcessTwo()
        {
            var ip = Configuration.IPb;
            var port = Configuration.Portb;
            var remoteIP = new IPEndPoint(IPAddress.Parse(ip), port);
            Listen(remoteIP);
        }

        public static void Listen(IPEndPoint remoteIP)
        {

        }

        public static void ProcessOrder(ExchangeAMd message)
        {
            LimitBook book = Books.Find(b => b.Contract.Equals(message.Contract));

            if (book == null)
            {
                var newBook = new LimitBook(message.Contract);
                Books.Add(newBook);
                book = newBook;
            }
            
            if (message.Type == MessageType.NewLevel)
            {
                book.ProcessNewOrder(message);
            }
            if (message.Type == MessageType.UpdateLevel)
            {
                book.ProcessModifyOrder(message);
            }
            if (message.Type == MessageType.DeleteLevel)
            {
                book.ProcessDeleteOrder(message);
            }

        }
    }
}
