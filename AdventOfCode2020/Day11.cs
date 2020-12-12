using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day11
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/11
        /// </summary>
        public static void Part1()
        {
            var layout = SeatLayout.Parse(Input.Get(11));
            var stable = layout.StabalizePart1();
            var count = stable.Count(SeatLayoutTile.OccupiedSeat);
            
            Console.WriteLine(count);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/11#part2
        /// </summary>
        public static void Part2()
        {
            var layout = SeatLayout.Parse(Input.Get(11));
            var stable = layout.StabalizePart2();
            var count = stable.Count(SeatLayoutTile.OccupiedSeat);
            
            Console.WriteLine(count);
        }
    }
}