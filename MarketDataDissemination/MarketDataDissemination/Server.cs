using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using MarketDataDissemination.Infrastructure;

namespace MarketDataDissemination
{
    public class Server
    {
        public Server()
        {
            IPa = Configuration.IPa;
            IPz = Configuration.IPz;
            Porta = Configuration.Porta;
            Portz = Configuration.Portz;
            ProbabilityParameter = Configuration.ProbabiltyParameter;
            EP1 = new IPEndPoint(IPAddress.Parse(IPa), Porta);
            EP2 = new IPEndPoint(IPAddress.Parse(IPz), Portz);
        }
        public string IPa { get; set; }

        public string IPz { get; set; }

        public int Porta { get; set; }

        public int Portz { get; set; }

        public IPEndPoint EP1 { get; set; }

        public IPEndPoint EP2 { get; set; }

        public double ProbabilityParameter { get; set; }

        public void GenerateData()
        {
            var contract = new List<string>() {"APPLE","IBM","GOOGLE","MICROSOFT","AMAZON","FACEBOOK"};
            
            bool sideFlag = false;
            var random = new Random();
            var sequence = 1;
            //UDPClient clientOne = new UDPClient(EP1);
            //UDPClient clientTwo = new UDPClient(EP2);
                    
            for (int i = 0; i < 5; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    var side = sideFlag ? LimitOrderSide.Sell : LimitOrderSide.Buy;
                    sideFlag = sideFlag != true;
                    var message = new ExchangeAMd(sequence++, contract[i], j, random.Next(500), random.Next(500), side,
                                                  MessageType.NewLevel);
                    var randomNum = random.Next(100);
                    string data = JsonHelper.JsonSerializer(message);

                    if (randomNum <= 100*ProbabilityParameter)
                    {
                        Client.Client.ProcessOrder(message);
                        Client.Client.ProcessOrder(message);
                        //clientOne.Send(data);
                        //clientTwo.Send(data);
                    }
                    else
                    {
                        Client.Client.ProcessOrder(message);
                        Client.Client.ProcessOrder(message);
                        //clientTwo.Send(data);
                        //clientOne.Send(data);
                    }
                }
            }
        }
    }
}
