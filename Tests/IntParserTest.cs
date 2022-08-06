using Microsoft.VisualStudio.TestTools.UnitTesting;
using NokLib.Parsers;

namespace NokLib
{
    [TestClass]
    public class IntParserTest
    {
        [TestMethod]
        public void Simple() {
            Assert.AreEqual(true, FastIntParser.TryParseS("123", out int result));
            Assert.AreEqual(123, result);
        }

        [TestMethod]
        public void SimpleNegative() {
            Assert.AreEqual(true, FastIntParser.TryParseS("-123", out int result));
            Assert.AreEqual(-123, result);
        }

        [TestMethod]
        public void Overflow() {
            Assert.AreEqual(false, FastIntParser.TryParseS(((long)int.MaxValue + 1).ToString(), out int result));
        }

        [TestMethod]
        public void Underflow() {
            Assert.AreEqual(false, FastIntParser.TryParseS(((long)int.MinValue - 1).ToString(), out int result));
        }

        [TestMethod]
        public void EmptyInput() {
            Assert.AreEqual(false, FastIntParser.TryParseS(string.Empty, out int result));
        }

        [TestMethod]
        public void MaxValue() {
            Assert.AreEqual(true, FastIntParser.TryParseS(int.MaxValue.ToString(), out int result));
            Assert.AreEqual(int.MaxValue, result);
        }

        [TestMethod]
        public void MinValue() {
            Assert.AreEqual(true, FastIntParser.TryParseS(int.MinValue.ToString(), out int result));
            Assert.AreEqual(int.MinValue, result);
        }

        [TestMethod]
        public void InvalidInput() {
            Assert.AreEqual(false, FastIntParser.TryParseS("Hello World", out int _));
        }
    }
}
