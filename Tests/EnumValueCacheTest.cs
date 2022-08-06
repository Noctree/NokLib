using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NokLib;

[TestClass]
public class EnumValueCacheTest
{
    [TestMethod]
    public void IsDefined() => Assert.IsTrue(EnumValueCache<ConsoleColor>.IsDefined(ConsoleColor.Red.ToInt()));

    [TestMethod]
    public void IsNotDefined() => Assert.IsFalse(EnumValueCache<ConsoleColor>.IsDefined(69));

    [TestMethod]
    public void TryParse() {
        Assert.IsTrue(EnumValueCache<ConsoleColor>.TryParse("Red", out var color));
        Assert.AreEqual(color, ConsoleColor.Red);
    }

    [TestMethod]
    public void TryNotParse() => Assert.IsFalse(EnumValueCache<ConsoleColor>.TryParse("bruh", out var color));

    [TestMethod]
    public void TryParseCaseInsensitive() {
        Assert.IsTrue(EnumValueCache<ConsoleColor>.TryParse("magenta", StringComparer.InvariantCultureIgnoreCase, out var color));
        Assert.AreEqual(color, ConsoleColor.Magenta);
    }
}
