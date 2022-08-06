using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NokLib;

[TestClass]
public class UnsafeCastingTest
{
    public enum LongEnum : long { FirstValue = 1, SecondValue, ThirdValue }
    public enum IntEnum : int { FirstValue = 1, SecondValue, ThirdValue }
    public enum ByteEnum : byte { FirstValue = 1, SecondValue, ThirdValue }
    [TestMethod]
    public void LongEnumToInt() => Assert.ThrowsException<UnsupportedTypeException>(() => LongEnum.SecondValue.ToIntFast());

    [TestMethod]
    public void IntEnumToInt() => IntEnum.FirstValue.ToIntFast();

    [TestMethod]
    public void ByteEnumToInt() => ByteEnum.ThirdValue.ToIntFast();

    [TestMethod]
    public void LongEnumToLong() => LongEnum.SecondValue.ToLongFast();

    [TestMethod]
    public void IntEnumToLong() => IntEnum.FirstValue.ToLongFast();

    [TestMethod]
    public void ByteEnumToLong() => ByteEnum.ThirdValue.ToLongFast();

    [TestMethod]
    public void FromLongToLongEnum() => 1L.ToEnumFast<LongEnum>();

    [TestMethod]
    public void FromIntToLongEnum() => 1.ToEnumFast<LongEnum>();

    [TestMethod]
    public void FromByteToLongEnum() => ((byte)1).ToEnumFast<LongEnum>();

    [TestMethod]
    public void FromLongToIntEnum() => 2L.ToEnumFast<IntEnum>();

    [TestMethod]
    public void FromIntToIntEnum() => 2.ToEnumFast<IntEnum>();

    [TestMethod]
    public void FromByteToIntEnum() => ((byte)2).ToEnumFast<IntEnum>();

    [TestMethod]
    public void FromLongToByteEnum() => 3L.ToEnumFast<ByteEnum>();

    [TestMethod]
    public void FromIntToByteEnum() => 3.ToEnumFast<ByteEnum>();

    [TestMethod]
    public void FromByteToByteEnum() => ((byte)3).ToEnumFast<ByteEnum>();
}
