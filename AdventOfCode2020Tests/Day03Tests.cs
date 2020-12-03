using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;

namespace AdventOfCode2020Tests
{
    public class Day03Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var map = TobogganMap.Parse(Input.Get(3));

            // When
            var path = map.GetPath(3, 1);
            var trees = path.Count(x => x == TobogganMapTile.Tree);

            // Then
            Assert.Equal(7, trees);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(3, 1, 7)]
        [InlineData(5, 1, 3)]
        [InlineData(7, 1, 4)]
        [InlineData(1, 2, 2)]
        public void Part2Test(int dx, int dy, int expectedTrees)
        {
            // Given
            var map = TobogganMap.Parse(Input.Get(3));

            // When
            var path = map.GetPath(dx, dy);
            var trees = path.Count(x => x == TobogganMapTile.Tree);

            // Then
            Assert.Equal(expectedTrees, trees);
        }
    }
}
