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
            var start = new [] { 0, 3, 6};
            var game = new MemoryGame(start);

            // When
            var play = game.Play().Take(10);

            // Then
            Assert.Equal(
                new [] { 0, 3, 6, 0, 3, 3, 1, 0, 4, 0 },
                play
            );
        }
    }
}
