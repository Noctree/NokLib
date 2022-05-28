using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NokLib;

namespace Tests
{
    [TestClass]
    public class MovingAverageTest
    {
        [TestMethod]
        public void Creation() {
            var average = new MovingAverage(5);
            Assert.AreEqual(0, average.Average);
        }

        [TestMethod]
        public void Single() {
            var average = new MovingAverage(5);
            average.Add(5);
            Assert.AreEqual(5, average.Average);
        }

        [TestMethod]
        public void Clear() {
            var average = new MovingAverage(5);
            average.Add(1);
            average.Add(2);
            average.Add(3);
            average.Add(4);
            average.Add(5);
            Assert.AreEqual(3, average.Average);
            average.Reset();
            Assert.AreEqual(0, average.Average);
        }

        [TestMethod]
        public void BasicAverage() {
            var average = new MovingAverage(5);
            average.Add(1);
            average.Add(2);
            average.Add(3);
            average.Add(4);
            average.Add(5);
            Assert.AreEqual(3, average.Average);
        }

        [TestMethod]
        public void AddRange() {
            var average = new MovingAverage(5);
            average.Add(1);
            average.Add(2);
            average.Add(3);
            average.Add(4);
            average.Add(5);
            Assert.AreEqual(3, average.Average);
            average.AddRange(new double[] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(3, average.Average);
        }

        [TestMethod]
        public void AddRangeAndAdd() {
            var average = new MovingAverage(5);
            average.AddRange(new double[] { 1, 2, 3, 4, 5 });
            Assert.AreEqual(3, average.Average);
            average.Add(6);
            Assert.AreEqual(4, average.Average);
        }

        [TestMethod]
        public void RandomValuesTestAddRange() {
            var rng = new SystemRandom(12);
            var values = new List<int>();
            for (int i = 0; i < 100; i++)
                values.Add(rng.NextInt(0, 1000));
            var linQAvg = values.Select(Convert.ToDouble).Average();
            MovingAverage calculator = new MovingAverage(5);
            var calculatorAverage = calculator.AddRange(values.Select(Convert.ToDouble));
            Assert.AreEqual(linQAvg, calculatorAverage);
            Assert.AreEqual(calculatorAverage, calculator.Average);
        }
    }
}
