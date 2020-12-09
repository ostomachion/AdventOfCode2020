using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day08
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/8
        /// </summary>
        public static void Part1()
        {
            var program = new HandheldProgram(Input.Get(8));
            var computer = new HandheldComputer(program);
            var accumulator = computer.Accumulator;

            var visited = new HashSet<int>();

            while (!visited.Contains(computer.ProgramCounter))
            {
                accumulator = computer.Accumulator;
                visited.Add(computer.ProgramCounter);
                computer.Step();
            }

            Console.WriteLine(accumulator);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/8#part2
        /// </summary>
        public static void Part2()
        {
            throw new NotImplementedException();
        }
    }
}