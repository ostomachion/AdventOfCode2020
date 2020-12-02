using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day01
    {
        public static IEnumerable<int> ParseInput(string input) => input.Split('\n').Select(Int32.Parse);

        public static void Part1()
        {
            var report = ParseInput(Input.Get(1));
            Console.WriteLine(FindProduct(2, report));
        }

        public static void Part2()
        {
            var report = ParseInput(Input.Get(1));
            Console.WriteLine(FindProduct(3, report));
        }

        public static BigInteger FindProduct(int numberOfTerms, IEnumerable<int> input)
        {
            return FindProduct(numberOfTerms, 2020, input.ToArray());

            static BigInteger FindProduct(int numberOfTerms, int goalSum, ReadOnlySpan<int> input)
            {
                if (numberOfTerms == 0)
                {
                    return goalSum == 0 ? 1 : 0;
                }

                for (var i = 0; i < input.Length; i++)
                {
                    var term = input[i];
                    if (term <= goalSum)
                    {
                        var product = FindProduct(numberOfTerms - 1, goalSum - term, input[(i + 1)..]);
                        if (!product.IsZero)
                        {
                            return product * term;
                        }
                    }
                }

                return 0;
            }
        }
    }
}