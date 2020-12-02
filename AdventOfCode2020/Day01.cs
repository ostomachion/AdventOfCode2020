using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day01
    {
        public static IEnumerable<int> ParseInput(string input) => input.Split('\n').Select(Int32.Parse);

        public static void Part1()
        {
            var report = ParseInput(Input.Get(1));
            Console.WriteLine(FindTerms(2, report));
        }

        public static void Part2()
        {
            var report = ParseInput(Input.Get(1));
            Console.WriteLine(FindTerms(3, report));
        }

        public static int? FindTerms(int numberOfTerms, IEnumerable<int> input) {
            var list = new List<int>();
            var value = FindTerms(numberOfTerms, 2020, input.ToArray(), list);
            return value;
        }

        private static int? FindTerms(int numberOfTerms, int goalSum, ReadOnlySpan<int> input, List<int> terms)
        {
            if (numberOfTerms == 0)
            {
                return goalSum == 0 ? 1 : null;
            }

            for (var i = 0; i < input.Length; i++)
            {
                var term = input[i];
                var product = FindTerms(numberOfTerms - 1, goalSum - term, input[i..], terms);
                if (product is not null)
                {
                    terms.Add(term);
                    return product * term;
                }
            }

            return null;
        }
    }
}