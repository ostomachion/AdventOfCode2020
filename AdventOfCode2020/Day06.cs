using System;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day06
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/6
        /// </summary>
        public static void Part1()
        {
            int sum = 0;
            var input = Input.GetGroups(6);
            var qs = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            foreach (var group in input)
            {
                var lines = group.Split("\n");
                    sum += qs.Count(x => lines.All(y => y.Contains(x)));
            }

            Console.WriteLine(sum);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/6#part2
        /// </summary>
        public static void Part2()
        {
            var input = Input.Get(6);

        }
    }
}