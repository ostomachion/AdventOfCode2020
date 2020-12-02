using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;

namespace AdventOfCode2020Tests
{
    public class Day01Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var report = Input.GetLines(1).Select(Int32.Parse);

            // When
            var product = Day01.FindProduct(2, report);

            // Then
            Assert.Equal(514579, product);
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var report = Input.GetLines(1).Select(Int32.Parse);
            
            // When
            var product = Day01.FindProduct(3,report);

            // Then
            Assert.Equal(241861950, product);
        }
    }
}
