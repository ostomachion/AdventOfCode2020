using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day10Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var joltages = Input.GetLines(10, "Short")
                .Select(int.Parse)
                .OrderBy(x => x)
                .Prepend(0)
                .ToList();
            joltages.Add(joltages.Max() + 3);

            // When
            var differences = Enumerable.Range(0, joltages.Count - 1)
                .Select(i => joltages[i + 1] - joltages[i]);

            // Then
            Assert.Equal(7, differences.Count(x => x == 1));
            Assert.Equal(5, differences.Count(x => x == 3));
        }
    }
}
