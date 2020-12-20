using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day19
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/189
        /// </summary>
        public static void Part1()
        {
            var groups = Input.GetGroups(19);
            var ruleSet = MessageRuleSet.Parse(groups[0]);
            var inputs = groups[1].Split('\n');

            var count = inputs.Count(ruleSet[0].Matches);

            Console.WriteLine(count);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/19#part2
        /// </summary>
        public static void Part2()
        {
            var groups = Input.GetGroups(19);
            var ruleSet = MessageRuleSet.Parse(groups[0]);
            var inputs = groups[1].Split('\n');

            ruleSet[8] = MessageRule.Parse("42 | 42 8");
            ruleSet[11] = MessageRule.Parse("42 31 | 42 11 31");

            var count = inputs.Count(ruleSet[0].Matches);

            Console.WriteLine(count);
        }
    }
}