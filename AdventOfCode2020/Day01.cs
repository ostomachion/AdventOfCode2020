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
            var report = new ReadOnlySpan<int>(ParseInput(Input.Get(1)).ToArray());
            Console.WriteLine(FindTerms(2, 2020, report, out _));
        }

        public static void Part2()
        {
            var report = new ReadOnlySpan<int>(ParseInput(Input.Get(1)).ToArray());
            Console.WriteLine(FindTerms(6, 2020, report, out _));
        }

        public static int? FindTerms(int numberOfTerms, int goalSum, ReadOnlySpan<int> input, out IEnumerable<int>? terms)
        {
            if (numberOfTerms == 0)
            {
                if (goalSum == 0)
                {
                    terms = Enumerable.Empty<int>();
                    return 1;
                }
                else
                {
                    terms = null;
                    return null;
                }
            }

            for (var i = 0; i < input.Length; i++)
            {
                var term = input[i];
                var product = FindTerms(numberOfTerms - 1, goalSum - term, input[i..], out terms);
                if (terms is not null)
                {
                    terms = new[] { term }.Concat(terms);
                    return product * term;
                }
            }

            terms = null;
            return null;
        }
    }
}