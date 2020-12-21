using System.Reflection.Metadata;
using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day20Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var tiles = Input.GetGroups(20).Select(ImageTile.Parse).ToList();

            // When
            var image = ImageTile.Arrange(tiles);
            Assert.NotNull(image);

            var width = image.GetLength(0);
            var height = image.GetLength(1);
            var topLeft = image[0, 0];
            var topRight = image[width - 1, 0];
            var bottomLeft = image[0, height - 1];
            var bottomRight = image[width - 1, height - 1];

            // Then
            Assert.Equal(20899048083289, (long)topLeft.Id * topRight.Id * bottomLeft.Id * bottomRight.Id);
        }
    }
}
