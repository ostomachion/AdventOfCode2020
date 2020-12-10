using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day09
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/9
        /// </summary>
        public static void Part1()
        {
            var cypher = new XmasCypher(Input.GetLines(9).Select(BigInteger.Parse));

            var nonSumNumber = cypher.FindNonSumNumber();

            Console.WriteLine(nonSumNumber);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/9#part2
        /// </summary>
        public static void Part2()
        {
            var cypher = new XmasCypher(Input.GetLines(9).Select(BigInteger.Parse));

            var key = cypher.FindKey(cypher.FindNonSumNumber()).ToArray();

            Console.WriteLine(key.Min() + key.Max());
        }
    }
}