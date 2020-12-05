using System;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day05
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/5
        /// </summary>
        public static void Part1()
        {
            var seatIds = Input.GetLines(5).Select(x => new BoardingPass(x).SeatId);
            Console.WriteLine(seatIds.Max());
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/5#part2
        /// </summary>
        public static void Part2()
        {
            var seatIds = Input.GetLines(5).Select(x => new BoardingPass(x).SeatId);
            for (var i = seatIds.Min() + 1; i < seatIds.Max(); i++)
            {
                if (!seatIds.Contains(i))
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}