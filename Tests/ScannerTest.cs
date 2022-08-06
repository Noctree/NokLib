using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NokLib;

[TestClass]
public class ScannerTest
{
    private StreamScanner scanner;
    private MemoryStream stream;

    [TestInitialize]
    public void Init() {
        stream = new MemoryStream();
        scanner = new StreamScanner(stream);
    }

    [TestMethod]
    public void Readline() {
        string message = "Hello World!";
        stream.StaticWrite(message.ToAsciiByteArray());
        Assert.AreEqual(message, scanner.ReadLine());
    }

    [TestMethod]
    public void ReadLineWithNewLine() {
        string message = "Hello World!";
        string extra = "this is garbage";
        stream.StaticWrite(string.Concat(message, "\n", extra).ToAsciiByteArray());
        Assert.AreEqual(message, scanner.ReadLine());
    }

    [TestMethod]
    public void ReadInt() {
        int number = 69420;
        stream.StaticWrite(number.ToString().ToAsciiByteArray());
        Assert.AreEqual(number, scanner.ReadInt());
    }

    [TestMethod]
    public void ReadIntPadded() {
        int number = 69420;
        stream.StaticWrite(string.Concat(number, "more garbage").ToAsciiByteArray());
        Assert.AreEqual(number, scanner.ReadInt());
    }

    [TestMethod]
    public void ReadNegativeInt() {
        int number = -1358008;
        stream.StaticWrite(number.ToString().ToAsciiByteArray());
        Assert.AreEqual(number, scanner.ReadInt());
    }

    [TestMethod]
    public void ReadNegativeIntPadded() {
        int number = -1358008;
        stream.StaticWrite(string.Concat(number, "even more garbage").ToAsciiByteArray());
        Assert.AreEqual(number, scanner.ReadInt());
    }

    [TestMethod]
    public void ReadMaxIntValue() {
        stream.StaticWrite(int.MaxValue.ToString().ToAsciiByteArray());
        Assert.AreEqual(int.MaxValue, scanner.ReadInt());
    }

    [TestMethod]
    public void ReadDoubleWithoutDecimal() {
        double number = 69;
        stream.StaticWrite(number.ToString().ToAsciiByteArray());
        Assert.AreEqual(number, scanner.ReadDouble());
    }

    [TestMethod]
    public void ReadDouble() {
        double number = 69.4201337;
        stream.StaticWrite(number.ToString().ToAsciiByteArray());
        Assert.AreEqual(number, scanner.ReadDouble());
    }

    [TestMethod]
    public void ReadNegativeDouble() {
        double number = -12345.6789;
        stream.StaticWrite(number.ToString().ToAsciiByteArray());
        Assert.AreEqual(number, scanner.ReadDouble());
    }

    [TestMethod]
    public void ReadNegativeDoubleWithoutDecimal() {
        double number = -69;
        stream.StaticWrite(number.ToString().ToAsciiByteArray());
        Assert.AreEqual(number, scanner.ReadDouble());
    }

    [TestMethod]
    public void ReadDoublePadded() {
        double number = 69.420;
        stream.StaticWrite(string.Concat(number, "Why even read this?").ToAsciiByteArray());
        Assert.AreEqual(number, scanner.ReadDouble());
    }

    [TestMethod]
    public void ReadLong() {
        long number = 12345678987654321;
        stream.StaticWrite(number.ToString().ToAsciiByteArray());
        Assert.AreEqual(number, scanner.ReadLong());
    }

    [TestMethod]
    public void ReadNegativeLong() {
        long number = -12345678987654321;
        stream.StaticWrite(number.ToString().ToAsciiByteArray());
        Assert.AreEqual(number, scanner.ReadLong());
    }

    [TestMethod]
    public void ReadLongMaxValue() {
        stream.StaticWrite(long.MaxValue.ToString().ToAsciiByteArray());
        Assert.AreEqual(long.MaxValue, scanner.ReadLong());
    }
}
