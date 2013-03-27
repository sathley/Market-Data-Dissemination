using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MarketDataDissemination.Client;

namespace MarketDataDissemination
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Start thread one
            //var t1 = new Thread(Client.Client.ProcessOne);
            //t1.Start();
            ////Start thread two
            //var t2 = new Thread(Client.Client.ProcessTwo);
            //t2.Start();
            Console.WriteLine("<------------------------------ Server Activated ------------------------------>");

            new Server().GenerateData();
            Console.WriteLine(Client.Client.Books.Count);
            //t1.Join();
            //t2.Join();
            Console.WriteLine("Hello world !");
            Console.ReadKey(true);

        }
    }
}
