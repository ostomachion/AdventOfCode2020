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
            var path = map.GetPath(3);
            var trees = path.Count(x => x == TobogganMapTile.Tree);

            // Then
            Assert.Equal(7, trees);
        }

        [Fact]
        public void Part2Test()
        {
            // Given

            // When

            // Then
            throw new NotImplementedException();
        }
    }
}
