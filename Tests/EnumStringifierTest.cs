using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NokLib;

[TestClass]
public class EnumStringifierTest
{
    [TestMethod]
    public void Simple() => Assert.AreEqual(ConsoleColor.White.ToString(), EnumStringifier.ToString(ConsoleColor.White));

    [TestMethod]
    public void Complex() {
        var values = Enum.GetValues(typeof(ConsoleColor)) as ConsoleColor[];

        for (int i = 0; i < values.Length; i++) {
            Assert.AreEqual(values[i].ToString(), EnumStringifier.ToString(values[i]));
        }
    }

    [TestMethod]
    public void MultipleSimple() {
        Assert.AreEqual(ConsoleColor.White.ToString(), EnumStringifier.ToString(ConsoleColor.White));
        Assert.AreEqual(DayOfWeek.Monday.ToString(), EnumStringifier.ToString(DayOfWeek.Monday));
    }

    [TestMethod]
    public void MultipleComplex() {
        var colors = Enum.GetValues(typeof(ConsoleColor)) as ConsoleColor[];
        var days = Enum.GetValues(typeof(DayOfWeek)) as DayOfWeek[];
        foreach (var item in colors.Zip(days)) {
            (var color, var day) = item;
            Assert.AreEqual(color.ToString(), EnumStringifier.ToString(color));
            Assert.AreEqual(day.ToString(), EnumStringifier.ToString(day));
        }
    }
}
