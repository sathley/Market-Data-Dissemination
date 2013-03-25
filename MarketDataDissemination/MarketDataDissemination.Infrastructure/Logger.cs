using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketDataDissemination.Infrastructure
{
    public class Logger
    {
        public string ServerLogFilePath { get; set; }

        public string ClientLogFilePath { get; set; }

        public Logger()
        {
            this.ServerLogFilePath = Configuration.ServerLogFilePath;
            this.ClientLogFilePath = Configuration.ClientLogFilePath;
        }
    }
}
