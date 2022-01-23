using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NokLib.Parsers;

namespace Tests
{
    [TestClass]
    public class ByteParserTest
    {
        [TestMethod]
        public void Simple()
        {
            Assert.AreEqual(true, FastByteParser.TryParseS("123", out byte result));
            Assert.AreEqual(123, result);
        }

        [TestMethod]
        public void Overflow()
        {
            Assert.AreEqual(false, FastByteParser.TryParseS("256", out byte result));
        }

        [TestMethod]
        public void Underflow()
        {
            Assert.AreEqual(false, FastByteParser.TryParseS("-1", out byte result));
        }

        [TestMethod]
        public void MaxValue()
        {
            Assert.AreEqual(true, FastByteParser.TryParseS(byte.MaxValue.ToString(), out byte result));
            Assert.AreEqual(byte.MaxValue, result);
        }

        [TestMethod]
        public void MinValue()
        {
            Assert.AreEqual(true, FastByteParser.TryParseS(byte.MinValue.ToString(), out byte result));
            Assert.AreEqual(byte.MinValue, result);
        }

        [TestMethod]
        public void InvalidInput()
        {
            Assert.AreEqual(false, FastByteParser.TryParseS("hello World", out byte _));
        }
    }
}
