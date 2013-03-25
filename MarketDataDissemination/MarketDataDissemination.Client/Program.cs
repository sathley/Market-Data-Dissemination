using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MarketDataDissemination.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<------------------------------ Client Activated ------------------------------>");
            //Start thread one
            new Thread(Client.ProcessOne).Start();
            //Start thread two
            new Thread(Client.ProcessTwo).Start();
        }

    }
}
