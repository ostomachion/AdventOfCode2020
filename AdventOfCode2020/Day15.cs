using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day15
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/15
        /// </summary>
        public static void Part1()
        {
            var start = Input.Get(15).Split(',').Select(int.Parse);
            var game = new MemoryGame(start);
            var n = game.Play().ElementAt(2020 - 1);

            Console.WriteLine(n);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/15#part2
        /// </summary>
        public static void Part2()
        {
            var start = Input.Get(15).Split(',').Select(int.Parse);
            var game = new MemoryGame(start);
            var n = game.Play().ElementAt(30000000 - 1);

            Console.WriteLine(n);
        }
    }
}