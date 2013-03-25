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

        public EndPoint EP1 { get; set; }

        public EndPoint EP2 { get; set; }

        public double ProbabilityParameter { get; set; }

        public void GenerateData()
        {
            var contract = new List<string>() {"APPLE","IBM","GOOGLE","MICROSOFT","AMAZON","FACEBOOK"};
            
            var random = new Random();
            
            for (int i = 0; i < 50; i++)
            {
                var message = new ExchangeAMd(i, contract[random.Next(0, contract.Count - 1)],);
            }
        }
    }
}
