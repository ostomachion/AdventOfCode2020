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
            var report = new ReadOnlySpan<int>(Day01.ParseInput(Input.Get(1)).ToArray());

            // When
            var product = Day01.FindTerms(2, 2020, report, out var terms);

            // Then
            Assert.Collection(terms,
                term => Assert.Equal(1721, term),
                term => Assert.Equal(299, term));
            Assert.Equal(514579, product);
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var report = new ReadOnlySpan<int>(Day01.ParseInput(Input.Get(1)).ToArray());

            // When
            var product = Day01.FindTerms(3, 2020, report, out var terms);

            // Then
            Assert.Collection(terms,
                term => Assert.Equal(979, term),
                term => Assert.Equal(366, term),
                term => Assert.Equal(675, term));
            Assert.Equal(241861950, product);
        }
    }
}
