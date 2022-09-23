using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NokLib;

[TestClass]
public class CastingTest
{
    public enum LongEnum : long { FirstValue = 1, SecondValue, ThirdValue }
    public enum IntEnum : int { FirstValue = 1, SecondValue, ThirdValue }
    public enum ByteEnum : byte { FirstValue = 1, SecondValue, ThirdValue }
    [TestMethod]
    public void LongEnumToInt() => Assert.ThrowsException<InvalidCastException>(() => LongEnum.SecondValue.ToInt());

    [TestMethod]
    public void IntEnumToInt() => IntEnum.FirstValue.ToInt();

    [TestMethod]
    public void ByteEnumToInt() => Assert.ThrowsException<InvalidCastException>(() => ByteEnum.ThirdValue.ToInt());

    [TestMethod]
    public void LongEnumToLong() => LongEnum.SecondValue.ToLong();

    [TestMethod]
    public void IntEnumToLong() => Assert.ThrowsException<InvalidCastException>(() => IntEnum.FirstValue.ToLong());

    [TestMethod]
    public void ByteEnumToLong() => Assert.ThrowsException<InvalidCastException>(() => ByteEnum.ThirdValue.ToLong());

    [TestMethod]
    public void FromLongToLongEnum() => 1L.ToEnum<LongEnum>();

    [TestMethod]
    public void FromIntToLongEnum() => Assert.ThrowsException<InvalidCastException>(() => 1.ToEnum<LongEnum>());

    [TestMethod]
    public void FromByteToLongEnum() => Assert.ThrowsException<InvalidCastException>(() => ((byte)1).ToEnum<LongEnum>());

    [TestMethod]
    public void FromLongToIntEnum() => Assert.ThrowsException<InvalidCastException>(() => 2L.ToEnum<IntEnum>());

    [TestMethod]
    public void FromIntToIntEnum() => 2.ToEnum<IntEnum>();

    [TestMethod]
    public void FromByteToIntEnum() => Assert.ThrowsException<InvalidCastException>(() => ((byte)2).ToEnum<IntEnum>());

    [TestMethod]
    public void FromLongToByteEnum() => Assert.ThrowsException<InvalidCastException>(() => 3L.ToEnum<ByteEnum>());

    [TestMethod]
    public void FromIntToByteEnum() => Assert.ThrowsException<InvalidCastException>(() => 3.ToEnum<ByteEnum>());

    [TestMethod]
    public void FromByteToByteEnum() => ((byte)3).ToEnum<ByteEnum>();
}
