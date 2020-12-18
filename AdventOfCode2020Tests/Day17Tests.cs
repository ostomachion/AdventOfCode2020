using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day17Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var grid = ConwayCubeGrid.FromSlice(Input.Get(17));

            // When
            for (var i = 0; i < 6; i++)
                grid.Step();

            // Then
            Assert.Equal(112, grid.ActiveCells.Count);
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var grid = ConwayCubeGrid4D.FromSlice(Input.Get(17));

            // When
            for (var i = 0; i < 6; i++)
                grid.Step();

            // Then
            Assert.Equal(848, grid.ActiveCells.Count);
        }
    }
}
