using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask04.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask04.Parser.Tests
{
    [TestClass()]
    public class TranslitParserTests
    {
        [DataTestMethod()]
        [DataRow("Круг", "Krug")]
        [DataRow("Корень","Korenb")]
        public void ToTranslitTest(string message,string translatedMessage)
        {
            //act
            string result = TranslitParser.ToTranslit(message);

            //assert
            Assert.AreEqual(result,translatedMessage);
        }
    }
}