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
            var (i, j) = FindTwoTerms(report);
            Console.WriteLine(i * j);
        }

        public static (int, int) FindTwoTerms(IEnumerable<int> input)
        {
            int i = input.First(x => input.Contains(2020 - x));
            return (i, 2020 - i);
        }

        public static (int, int, int) FindThreeTerms(IEnumerable<int> input)
        {
            throw new NotImplementedException();
        }
    }
}