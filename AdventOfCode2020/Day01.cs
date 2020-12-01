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
            var (i, j) = FindTwoTerms(2020, report)!.Value;
            Console.WriteLine(i * j);
        }

        public static void Part2()
        {
            var (i, j, k) = FindThreeTerms(2020, report)!.Value;
            Console.WriteLine(i * j * k);
        }

        public static (int, int)? FindTwoTerms(int sum, IEnumerable<int> input)
        {
            foreach (var i in input)
            {
                if (input.Contains(sum - i))
                {
                    return (i, sum - i);
                }
            }
            return null;
        }

        public static (int, int, int)? FindThreeTerms(int sum, IEnumerable<int> input)
        {
            foreach (var i in input)
            {
                var test = FindTwoTerms(sum - i, input);
                if (test.HasValue)
                {
                    var (j, k) = test.Value;
                    return (i, j, k);
                }
            }
            return null;
        }
    }
}