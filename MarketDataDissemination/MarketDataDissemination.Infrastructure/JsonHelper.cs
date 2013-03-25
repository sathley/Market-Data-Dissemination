using System.IO;
using System.Runtime.Serialization.Json;

namespace MarketDataDissemination.Infrastructure
{
    public  class JsonHelper
    {
        public static string JsonSerializer<T>(T t)
        {
            var ser = new DataContractJsonSerializer(typeof(T));
            var ms = new MemoryStream();
            ser.WriteObject(ms, t);
            var jsonString = EncodingUtility.Decode(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        public static T JsonDeserialize<T>(string jsonString)
        {
            var ser = new DataContractJsonSerializer(typeof(T));
            var ms = new MemoryStream(EncodingUtility.Encode(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
    }
}