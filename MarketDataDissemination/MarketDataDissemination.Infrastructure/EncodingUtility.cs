using System.Text;

namespace MarketDataDissemination.Infrastructure
{
    public static class EncodingUtility
    {
        public static byte[] Encode(string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }

        public static string Decode(byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }
    }
}