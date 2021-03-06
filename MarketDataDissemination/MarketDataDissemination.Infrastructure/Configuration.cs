﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MarketDataDissemination.Infrastructure
{
    public static class Configuration
    {
        public static string IPa
        {
            get { return ConfigurationManager.AppSettings["IPa"]; }
        }

        public static int Porta
        {
            get { return int.Parse(ConfigurationManager.AppSettings["Porta"]); }
        }

        public static string IPz
        {
            get { return ConfigurationManager.AppSettings["IPz"]; }
        }

        public static int Portz
        {
            get { return int.Parse(ConfigurationManager.AppSettings["Portz"]); }
        }

        public static double ProbabiltyParameter
        {
            get { return double.Parse(ConfigurationManager.AppSettings["probabilityParameter"]); }
        }

        public static string ServerLogFilePath
        {
            get { return ConfigurationManager.AppSettings["serverLogFilePath"]; }
        }

        public static string ClientLogFilePath
        {
            get { return ConfigurationManager.AppSettings["clientLogFilePath"]; }
        }
    }
}
