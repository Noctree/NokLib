using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NokLib
{
    [TestClass]
    public class RingBufferTest
    {
        [TestMethod]
        public void Add() {
            RingBuffer<int> buffer = new RingBuffer<int>(5);
            buffer.Add(1);
            buffer.Add(2);
            buffer.Add(3);
            buffer.Add(4);
            buffer.Add(5);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, buffer.ToArray());
        }

        [TestMethod]
        public void Overriding() {
            RingBuffer<int> buffer = new RingBuffer<int>(5);
            buffer.AddRange(new int[] { 1, 2, 3, 4, 5 });
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, buffer.ToArray());
            buffer.Add(6);
            CollectionAssert.AreEqual(new int[] { 2, 3, 4, 5, 6 }, buffer.ToArray());
        }

        [TestMethod]
        public void Clear() {
            RingBuffer<int> buffer = new RingBuffer<int>(5);
            buffer.AddRange(new int[] { 1, 2, 3, 4, 5 });
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, buffer.ToArray());
            buffer.Clear();
            CollectionAssert.AreEqual(new int[] { 0, 0, 0, 0, 0 }, buffer.ToArray());
        }

        [TestMethod]
        public void Contains() {
            RingBuffer<int> buffer = new RingBuffer<int>(5);
            buffer.AddRange(new int[] { 1, 2, 3, 4, 5 });
            Assert.IsFalse(buffer.Contains(6));
            Assert.IsTrue(buffer.Contains(1));
            buffer.Add(6);
            Assert.IsFalse(buffer.Contains(1));
            Assert.IsTrue(buffer.Contains(6));
        }
    }
}
