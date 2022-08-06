using Microsoft.VisualStudio.TestTools.UnitTesting;
using NokLib.Parsers;

namespace NokLib
{
    [TestClass]
    public class SByteParserTest
    {
        [TestMethod]
        public void Simple() {
            Assert.AreEqual(true, FastSByteParser.TryParseS("123", out sbyte result));
            Assert.AreEqual(123, result);
        }

        [TestMethod]
        public void SimpleNegative() {
            Assert.AreEqual(true, FastSByteParser.TryParseS("-123", out sbyte result));
            Assert.AreEqual(-123, result);
        }

        [TestMethod]
        public void Overflow() {
            Assert.AreEqual(false, FastSByteParser.TryParseS("128", out sbyte _));
        }

        [TestMethod]
        public void Underflow() {
            Assert.AreEqual(false, FastSByteParser.TryParseS("-129", out sbyte _));
        }

        [TestMethod]
        public void MaxValue() {
            Assert.AreEqual(true, FastSByteParser.TryParseS(sbyte.MaxValue.ToString(), out sbyte result));
            Assert.AreEqual(sbyte.MaxValue, result);
        }

        [TestMethod]
        public void MinValue() {
            Assert.AreEqual(true, FastSByteParser.TryParseS(sbyte.MinValue.ToString(), out sbyte result));
            Assert.AreEqual(sbyte.MinValue, result);
        }

        [TestMethod]
        public void InvalidInput() {
            Assert.AreEqual(false, FastSByteParser.TryParseS("hello World", out sbyte _));
        }
    }
}
