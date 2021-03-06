using System;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day07
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/7
        /// </summary>
        public static void Part1()
        {
            var rules = new LuggageRuleSet(Input.GetLines(7).Select(x => new LuggageRule(x)));

            var colors = rules.Rules.Select(x => x.Color);
            var canHoldShinyGold = colors.Where(x => rules.CanEventuallyContain(x, "shiny gold"))
                .OrderBy(x => x);

            Console.WriteLine(canHoldShinyGold.Count());
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/7#part2
        /// </summary>
        public static void Part2()
        {
            var rules = new LuggageRuleSet(Input.GetLines(7).Select(x => new LuggageRule(x)));

            Console.WriteLine(rules.CountBags("shiny gold"));
        }
    }
}