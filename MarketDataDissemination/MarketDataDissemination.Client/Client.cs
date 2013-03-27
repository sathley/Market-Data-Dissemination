using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using MarketDataDissemination.Infrastructure;

namespace MarketDataDissemination.Client
{
    public static class Client
    {
        public static List<LimitBook> Books = new List<LimitBook>();

        public static long LastHighestSequenceNumber = 0;

        public static int CountOfMessagesProcessed = 0;

        public static void ProcessOne()
        {
            var ip = Configuration.IPa;
            var port = Configuration.Porta;
            var remoteIP = new IPEndPoint(IPAddress.Parse(ip), port);
            Listen(remoteIP);
        }

        public static void ProcessTwo()
        {
            var ip = Configuration.IPz;
            var port = Configuration.Portz;
            var remoteIP = new IPEndPoint(IPAddress.Parse(ip), port);
            Listen(remoteIP);
        }

        public static void Listen(IPEndPoint remoteIP)
        {
            var done = false;

            var listener = new UdpClient(remoteIP);
            listener.Connect(remoteIP);
            var groupEP = new IPEndPoint(IPAddress.Any, remoteIP.Port);
            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for broadcast..");
                    byte[] bytes = listener.Receive(ref groupEP);
                    string json = EncodingUtility.Decode(bytes);
                    Console.WriteLine("Received broadcast from {0}:{1} :\n {2}\n", groupEP.Address,groupEP.Port, json);
                    var message = JsonHelper.JsonDeserialize<ExchangeAMd>(json);
                    //Do aaync
                    ProcessOrder(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }

        public static void ProcessOrder(ExchangeAMd message)
        {
            if(message.Sequence <= LastHighestSequenceNumber)
                return;
            if(message.Sequence > LastHighestSequenceNumber + 1)
                //Inconsistent state (Message lost)
            LastHighestSequenceNumber = message.Sequence;

            LimitBook book;
            lock (Books)
            {
                book = Books.Find(b => b.Contract.Equals(message.Contract));
                if (book == null)
                {
                    var newBook = new LimitBook(message.Contract);
                    Books.Add(newBook);
                    book = newBook;
                }
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
