using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day15Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var start = new[] { 0, 3, 6 };
            var game = new MemoryGame(start);

            // When
            var play = game.Play().Take(10);

            // Then
            Assert.Equal(
                new[] { 0, 3, 6, 0, 3, 3, 1, 0, 4, 0 },
                play
            );
        }

        [Theory]
        [InlineData(0, 3, 6, 175594)]
        [InlineData(1, 3, 2, 2578)]
        [InlineData(2, 1, 3, 3544142)]
        [InlineData(1, 2, 3, 261214)]
        [InlineData(2, 3, 1, 6895259)]
        [InlineData(3, 2, 1, 18)]
        [InlineData(3, 1, 2, 362)]
        public void Part2Test(int n1, int n2, int n3, int value)
        {
            // Given
            var start = new[] { n1, n2, n3 };
            var game = new MemoryGame(start);

            // When
            var actual = game.Play().Take(30000000).Last();

            // Then
            Assert.Equal(value, actual);
        }
    }
}
