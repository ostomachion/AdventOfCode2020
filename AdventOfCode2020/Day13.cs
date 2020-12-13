using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day13
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/13
        /// </summary>
        public static void Part1()
        {
            var obj = Day13Object.Parse(Input.Get(13));
            
            var result = obj.Work();

            Console.WriteLine(result);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/13#part2
        /// </summary>
        public static void Part2()
        {
            var object = Day13Object.Parse(Input.Get(13));
            
            var result = object.Work();

            Console.WriteLine(result);
        }
    }
}