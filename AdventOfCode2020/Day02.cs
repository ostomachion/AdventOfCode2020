using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day02
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/2
        /// </summary>
        public static void Part1()
        {
            var list = Input.GetLines(2).Select(PasswordLine.Parse);

            Console.WriteLine(list.Count(x => x.Policy.OldSystemCheck(x.Password)));
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/2#part2
        /// </summary>
        public static void Part2()
        {
            var list = Input.GetLines(2).Select(PasswordLine.Parse);

            Console.WriteLine(list.Count(x => x.Policy.NewSystemCheck(x.Password)));
        }
    }
}