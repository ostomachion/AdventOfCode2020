using System;
using System.Collections.Generic;
using System.Linq;

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
            var path = map.GetPath(3);
            var trees = path.Count(x => x == TobogganMapTile.Tree);

            Console.WriteLine(trees);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/2#part3
        /// </summary>
        public static void Part2()
        {
            throw new NotImplementedException();
        }
    }
}