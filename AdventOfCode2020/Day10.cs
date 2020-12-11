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
            var joltages = Input.GetLines(10).Select(int.Parse);
            joltages = joltages.Append(0).Append(joltages.Max() + 3);
            
            Console.WriteLine(GetCounts(joltages)[0]);
        }

        public static Dictionary<int, BigInteger> GetCounts(IEnumerable<int> joltages)
        {
            var ordered = joltages.OrderByDescending(x => x).ToList();
            var value = new Dictionary<int, BigInteger> { [ordered[0]] = 1 };
            for (int i = 1; i < ordered.Count; i++)
            {
                value.Add(ordered[i], 0);
                for (var j = i - 1; j >= 0; j--)
                {
                    if (ordered[j] - ordered[i] > 3)
                        break;
                    value[ordered[i]] += value[ordered[j]];
                }
            }
            return value;
        }
    }
}