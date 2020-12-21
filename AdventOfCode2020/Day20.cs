using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day20
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/20
        /// </summary>
        public static void Part1()
        {
            // Given
            var tiles = Input.GetGroups(20).Select(ImageTile.Parse).ToList();

            // When
            var image = ImageTile.Arrange(tiles)!;

            var width = image.GetLength(0);
            var height = image.GetLength(1);
            var topLeft = image[0, 0];
            var topRight = image[width - 1, 0];
            var bottomLeft = image[0, height - 1];
            var bottomRight = image[width - 1, height - 1];

            // Then
            Console.WriteLine((long)topLeft.Id * topRight.Id * bottomLeft.Id * bottomRight.Id);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/20#part2
        /// </summary>
        public static void Part2()
        {
            

        }
    }
}