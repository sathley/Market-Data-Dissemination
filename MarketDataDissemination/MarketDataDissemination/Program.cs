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
            //Start thread one
            new Thread(Client.Client.ProcessOne).Start();
            //Start thread two
            new Thread(Client.Client.ProcessTwo).Start();
            Console.WriteLine("<------------------------------ Server Activated ------------------------------>");
        }
    }
}
