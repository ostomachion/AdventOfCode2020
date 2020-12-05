using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;

namespace AdventOfCode2020Tests
{
    public class Day04Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var passports = Input.Get(4).Split("\n\n").Select(PassportData.Parse);

            // When
            var status = passports.Select(x => x.IsComplete);

            // Then
            Assert.Equal(new[] { true, false, true, false }, status);
        }

        [Fact]
        public void Part2Test()
        {
            // Given

            // When

            // Then
            Assert.True(false); // TODO:
        }
    }
}
