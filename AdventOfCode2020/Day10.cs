using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day10
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/10
        /// </summary>
        public static void Part1()
        {
            var joltages = Input.GetLines(10)
                .Select(int.Parse)
                .OrderBy(x => x)
                .Prepend(0)
                .ToList();
            joltages.Add(joltages.Max() + 3);

            var differences = Enumerable.Range(0, joltages.Count - 1)
                .Select(i => joltages[i + 1] - joltages[i]);

            Console.WriteLine(differences.Count(x => x == 1) * differences.Count(x => x == 3));
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/10#part2
        /// </summary>
        public static void Part2()
        {
            throw new NotImplementedException();
        }
    }
}