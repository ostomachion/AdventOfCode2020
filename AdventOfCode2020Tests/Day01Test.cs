using System.Collections.Generic;
using NUnit.Framework;
using AdventOfCode2020;

namespace AdventOfCode2020Tests
{
    public class Day01Tests
    {
        [Test]
        public void FindTwoTermsTest()
        {
            // Given
            var report = Day01.ParseInput(@"1721
979
366
299
675
1456");

            // When
            var (i, j) = Day01.FindTwoTerms(report);

            // Then
            Assert.AreEqual(1721, i);
            Assert.AreEqual(299, j);
            Assert.AreEqual(514579, i * j);
        }

        [Test]
        public void FindThreeTermsTest()
        {
            // Given
            var report = Day01.ParseInput(@"1721
979
366
299
675
1456");

            // When
            var (i, j, k) = Day01.FindThreeTerms(report);

            // Then
            Assert.AreEqual(979, i);
            Assert.AreEqual(366, j);
            Assert.AreEqual(675, k);
            Assert.AreEqual(241861950, i * j * k);
        }
    }
}