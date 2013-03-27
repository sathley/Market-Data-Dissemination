using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;


namespace MarketDataDissemination.Infrastructure
{
    public class UDPClient
    {
        private UdpClient Internal { get; set; }

        private IPAddress IP { get; set; }

        private int Port { get; set; }

        public UDPClient(IPEndPoint endPoint)
        {
            Internal = new UdpClient(endPoint);
            this.IP = endPoint.Address;
            this.Port = endPoint.Port;
            Internal.Connect(endPoint);
        }

        public void Send(string data)
        {
            Internal.Send(EncodingUtility.Encode(data), data.Length);
        }

        //public string Recieve()
        //{
        //    var ipEp = new IPEndPoint(this.IP, this.Port);
        //    return EncodingUtility.Decode(Internal.Receive(ref ipEp));
        //}
    }
}
