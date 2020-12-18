using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day17
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/17
        /// </summary>
        public static void Part1()
        {
            var grid = ConwayCubeGrid.FromSlice(Input.Get(17));

            for (var i = 0; i < 6; i++)
                grid.Step();

            Console.WriteLine(grid.ActiveCells.Count);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/17#part2
        /// </summary>
        public static void Part2()
        {
            var grid = ConwayCubeGrid4D.FromSlice(Input.Get(17));

            for (var i = 0; i < 6; i++)
                grid.Step();

            Console.WriteLine(grid.ActiveCells.Count);
        }
    }
}