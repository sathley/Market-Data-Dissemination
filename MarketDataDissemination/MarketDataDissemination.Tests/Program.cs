using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketDataDissemination.Tests
{
    [TestClass]
    public class BinaryFileTest
    {
        [TestMethod]
        public  void ConvertbinaryToText()
        {
            var fileBytes = File.ReadAllBytes("D:/test_binary.bin");
            var sb = new StringBuilder();

            foreach (var b in fileBytes)
            {
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }

            File.WriteAllText("D:/test_text.txt", sb.ToString());
        }
    }
}
