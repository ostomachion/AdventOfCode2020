using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day24
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/24
        /// </summary>
        public static void Part1()
        {
            var list = Input.GetLines(24).Select(HexGrid.GetCoordinate);
            var grid = new HexGrid();

            foreach (var (X, Y) in list)
            {
                grid.Flip(X, Y);
            }

            Console.WriteLine(grid.BlackTiles.Count);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/24#part2
        /// </summary>
        public static void Part2()
        {
            var list = Input.GetLines(24).Select(HexGrid.GetCoordinate);
            var grid = new HexGrid();

            foreach (var (X, Y) in list)
            {
                grid.Flip(X, Y);
            }

            for (var i = 0; i < 100; i++)
            {
                grid.Update();
            }

            Console.WriteLine(grid.BlackTiles.Count);
        }
    }
}