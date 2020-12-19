using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day18
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/18
        /// </summary>
        public static void Part1()
        {
            var expressions = Input.GetLines(18);
            var answers = expressions.Select(NewMathExpression.Evaluate);

            Console.WriteLine(answers.Aggregate(BigInteger.Zero, (x, y) => x + y));
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/18#part2
        /// </summary>
        public static void Part2()
        {
            var expressions = Input.GetLines(18);
            var answers = expressions.Select(NewMathExpression.EvaluateAdvanced);

            Console.WriteLine(answers.Aggregate(BigInteger.Zero, (x, y) => x + y));
        }
    }
}