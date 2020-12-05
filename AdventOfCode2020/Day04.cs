using System;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day04
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/4
        /// </summary>
        public static void Part1()
        {
            var passports = Input.Get(4).Split("\n\n").Select(PassportData.Parse);

            // When
            Console.WriteLine(passports.Count(x => x.IsComplete));
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/4#part2
        /// </summary>
        public static void Part2()
        {
            var passports = Input.Get(4).Split("\n\n").Select(PassportData.Parse);

            // When
            Console.WriteLine(passports.Count(x => x.IsValidPassport(out _)));
        }
    }
}