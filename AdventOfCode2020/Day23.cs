using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day23
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/23
        /// </summary>
        public static void Part1()
        {
            var game = new CupGame("469217538".Select(c => int.Parse(c.ToString())).ToList());
            for (var i = 0; i < 100; i++)
            {
                game.Move();
            }

            Console.WriteLine(game.ToString(1)[1..]);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/23#part2
        /// </summary>
        public static void Part2()
        {
            
        }
    }
}