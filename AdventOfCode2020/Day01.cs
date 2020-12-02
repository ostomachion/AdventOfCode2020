using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day01
    {
        /// <summary>
        /// Converts a string containing a positive integer on each line to an <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>A collection of positive integers.</returns>
        public static IEnumerable<int> ParseInput(string[] input) => input.Select(Int32.Parse);

        /// <summary>
        /// https://adventofcode.com/2020/day/1
        /// </summary>
        public static void Part1()
        {
            var report = ParseInput(Input.GetLines(1));
            Console.WriteLine(FindProduct(2, report));
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/1#part2
        /// </summary>
        public static void Part2()
        {
            var report = ParseInput(Input.GetLines(1));
            Console.WriteLine(FindProduct(3, report));
        }

        /// <summary>
        /// Returns the product of <paramref name="numberOfTerms"/> distinct values
        /// from <paramref name="input"/> which sum to 2020.
        /// </summary>
        /// <param name="numberOfTerms">The number of terms to look for.</param>
        /// <param name="input">The list of positive integers to choose from.</param>
        /// <returns>The product of the terms which sum to 2020.</returns>
        public static BigInteger FindProduct(int numberOfTerms, IEnumerable<int> input)
        {
            if (input.Any(x => x < 0))
                throw new ArgumentException("All input terms must be positive.", nameof(input));

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