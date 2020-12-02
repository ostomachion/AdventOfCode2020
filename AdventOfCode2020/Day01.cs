using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day01
    {
        public static IEnumerable<int> ParseInput(string input) => input.Split('\n').Select(Int32.Parse);

        private static IEnumerable<int> report = ParseInput(Input.Get(1));

        public static void Part1()
        {
            var result = FindTerms(2, 2020, report)!.ToArray();
            Console.WriteLine(result[0] * result[1]);
        }

        public static void Part2()
        {
            var result = FindTerms(3, 2020, report)!.ToArray();
            Console.WriteLine(result[0] * result[1] * result[2]);
        }

        public static IEnumerable<int>? FindTerms(int numberOfTerms, int goalSum, IEnumerable<int> input)
        {
            if (numberOfTerms == 0)
            {
                return goalSum == 0 ? Enumerable.Empty<int>() : null;
            }

            foreach (var item in input)
            {
                var test = FindTerms(numberOfTerms - 1, goalSum - item, input.Except(new[] { item }));
                if (test is not null)
                    return new[] { item }.Concat(test);
            }

            return null;
        }
    }
}