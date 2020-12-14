using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day14
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/14
        /// </summary>
        public static void Part1()
        {
            // Given
            var obj = Day14Obj.Parse(Input.GetLines(14));
            

            // When
            obj.Run();

            //Then
            System.Console.WriteLine(obj.Sum());
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/14#part2
        /// </summary>
        public static void Part2()
        {
            // var obj = Day14Obj.Parse(Input.Get(14));
            // var value = obj.Run();
            // Console.WriteLine(value);
        }
    }
}