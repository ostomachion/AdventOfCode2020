using System.Reflection.Metadata;
using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day24Tests
    {
        [Fact]
        public void CoordinateTest()
        {
            Assert.Equal((0, 0), HexGrid.GetCoordinate("nwwswee"));
        }

        [Fact]
        public void Part1Test()
        {
            // Given
            var list = Input.GetLines(24).Select(HexGrid.GetCoordinate);
            var grid = new HexGrid();

            // When
            foreach (var (x, y) in list)
            {
                grid.Flip(x, y);
            }

            // Then
            Assert.Equal(10, grid.BlackTiles.Count);
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var list = Input.GetLines(24).Select(HexGrid.GetCoordinate);
            var grid = new HexGrid();

            foreach (var (x, y) in list)
            {
                grid.Flip(x, y);
            }

            grid.Update();
            Assert.Equal(15, grid.BlackTiles.Count);

            grid.Update();
            Assert.Equal(12, grid.BlackTiles.Count);

            grid.Update();
            Assert.Equal(25, grid.BlackTiles.Count);

            grid.Update();
            Assert.Equal(14, grid.BlackTiles.Count);

            grid.Update();
            Assert.Equal(23, grid.BlackTiles.Count);

            grid.Update();
            Assert.Equal(28, grid.BlackTiles.Count);
            
            grid.Update();
            Assert.Equal(41, grid.BlackTiles.Count);

            grid.Update();
            Assert.Equal(37, grid.BlackTiles.Count);

            grid.Update();
            Assert.Equal(49, grid.BlackTiles.Count);

            grid.Update();
            Assert.Equal(37, grid.BlackTiles.Count);

            for (var i = 0; i < 10; i++)
                grid.Update();
            Assert.Equal(132, grid.BlackTiles.Count);

            for (var i = 0; i < 10; i++)
                grid.Update();
            Assert.Equal(259, grid.BlackTiles.Count);

            for (var i = 0; i < 10; i++)
                grid.Update();
            Assert.Equal(406, grid.BlackTiles.Count);

            for (var i = 0; i < 10; i++)
                grid.Update();
            Assert.Equal(566, grid.BlackTiles.Count);

            for (var i = 0; i < 10; i++)
                grid.Update();
            Assert.Equal(788, grid.BlackTiles.Count);

            for (var i = 0; i < 10; i++)
                grid.Update();
            Assert.Equal(1106, grid.BlackTiles.Count);

            for (var i = 0; i < 10; i++)
                grid.Update();
            Assert.Equal(1373, grid.BlackTiles.Count);

            for (var i = 0; i < 10; i++)
                grid.Update();
            Assert.Equal(1844, grid.BlackTiles.Count);

            for (var i = 0; i < 10; i++)
                grid.Update();
            Assert.Equal(2208, grid.BlackTiles.Count);
        }
    }
}
