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
            var computer = new SeaPortComputer();
            var program = SeaPortProgram.Parse(Input.Get(14));
            computer.Run(program, false);

            Console.WriteLine(Sum(computer));
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/14#part2
        /// </summary>
        public static void Part2()
        {
            var computer = new SeaPortComputer();
            var program = SeaPortProgram.Parse(Input.Get(14));

            computer.Run(program, true);

            Console.WriteLine(Sum(computer));
        }

        public static BigInteger Sum(SeaPortComputer computer)
        {
            return computer.Memory.Aggregate(BigInteger.Zero, (x, y) => x + y.Value);
        }
    }
}