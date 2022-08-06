using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NokLib
{
    [TestClass]
    public class CastingTest
    {
        public enum LongEnum : long { FirstValue = 1, SecondValue, ThirdValue }
        public enum IntEnum : int { FirstValue = 1, SecondValue, ThirdValue }
        public enum ByteEnum : byte { FirstValue = 1, SecondValue, ThirdValue }
        [TestMethod]
        public void LongEnumToInt() => LongEnum.SecondValue.ToInt();

        [TestMethod]
        public void IntEnumToInt() => IntEnum.FirstValue.ToInt();

        [TestMethod]
        public void ByteEnumToInt() => ByteEnum.ThirdValue.ToInt();

        [TestMethod]
        public void LongEnumToLong() => LongEnum.SecondValue.ToLong();

        [TestMethod]
        public void IntEnumToLong() => IntEnum.FirstValue.ToLong();

        [TestMethod]
        public void ByteEnumToLong() => ByteEnum.ThirdValue.ToLong();

        [TestMethod]
        public void FromLongToLongEnum() => 1L.ToEnum<LongEnum>();

        [TestMethod]
        public void FromIntToLongEnum() => 1.ToEnum<LongEnum>();

        [TestMethod]
        public void FromByteToLongEnum() => ((byte)1).ToEnum<LongEnum>();

        [TestMethod]
        public void FromLongToIntEnum() => 2L.ToEnum<IntEnum>();

        [TestMethod]
        public void FromIntToIntEnum() => 2.ToEnum<IntEnum>();

        [TestMethod]
        public void FromByteToIntEnum() => ((byte)2).ToEnum<IntEnum>();

        [TestMethod]
        public void FromLongToByteEnum() => 3L.ToEnum<ByteEnum>();

        [TestMethod]
        public void FromIntToByteEnum() => 3.ToEnum<ByteEnum>();

        [TestMethod]
        public void FromByteToByteEnum() => ((byte) 3).ToEnum<ByteEnum>();
    }
}
