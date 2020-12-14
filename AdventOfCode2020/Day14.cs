using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day14
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/14
        /// </summary>
        public static void Part1()
        {
            var obj = Day14Obj.Parse(Input.Get(14));
            var value = obj.Run();
            Console.WriteLine(value);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/14#part2
        /// </summary>
        public static void Part2()
        {
            var obj = Day14Obj.Parse(Input.Get(14));
            var value = obj.Run();
            Console.WriteLine(value);
        }
    }
}