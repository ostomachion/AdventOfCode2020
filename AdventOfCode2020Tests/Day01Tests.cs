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
            var report = Day01.ParseInput(Input.Get(1));

            // When
            var product = Day01.FindTerms(2, report);

            // Then
            Assert.Equal(514579, product);
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var report = Day01.ParseInput(Input.Get(1));

            // When
            var product = Day01.FindTerms(3,report);

            // Then
            Assert.Equal(241861950, product);
        }
    }
}
