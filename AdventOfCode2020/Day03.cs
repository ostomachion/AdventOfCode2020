using System;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day03
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/3
        /// </summary>
        public static void Part1()
        {
            var map = TobogganMap.Parse(Input.Get(3));
            var path = map.GetPath(3, 1);
            var trees = path.Count(x => x == TobogganMapTile.Tree);

            Console.WriteLine(trees);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/3#part2
        /// </summary>
        public static void Part2()
        {
            var map = TobogganMap.Parse(Input.Get(3));
            BigInteger product = 1;
            foreach (var (dx, dy) in new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) })
            {
                var path = map.GetPath(dx, dy);
                product *= path.Count(x => x == TobogganMapTile.Tree);
            }

            Console.WriteLine(product);
        }
    }
}