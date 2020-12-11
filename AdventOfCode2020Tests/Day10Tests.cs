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
        [Theory]
        [InlineData("Short", 7, 5)]
        [InlineData("Long", 22, 10)]
        public void Part1Test(string id, int diff1, int diff3)
        {
            // Given
            var joltages = Input.GetLines(10, id)
                .Select(int.Parse)
                .OrderBy(x => x)
                .Prepend(0)
                .ToList();
            joltages.Add(joltages.Max() + 3);

            // When
            var differences = Enumerable.Range(0, joltages.Count - 1)
                .Select(i => joltages[i + 1] - joltages[i]);

            // Then
            Assert.Equal(diff1, differences.Count(x => x == 1));
            Assert.Equal(diff3, differences.Count(x => x == 3));
        }

        [Theory]
        [InlineData("Short", 8)]
        [InlineData("Long", 19208)]
        public void Part2Test(string id, int combos)
        {
            // Given
            var joltages = Input.GetLines(10, id)
                .Select(int.Parse);
            joltages = joltages.Append(0).Append(joltages.Max() + 3);
            
            // When
            var counts = Day10.GetCounts(joltages);

            // Then
            Assert.Equal(combos, counts[0]);
        }
    }
}
