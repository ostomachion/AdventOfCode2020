using System;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day06
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/6
        /// </summary>
        public static void Part1()
        {
            var answers = Input.GetGroups(6).Select(x => new CustomsDeclarationFormGroupAnswers(x));
            
            var count = answers.Sum(a => CustomsDeclarationFormAnswers.Questions
                .Count(x => a.Answers.Any(y => y.Answer(x))));

            Console.Write(count);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/6#part2
        /// </summary>
        public static void Part2()
        {
            var answers = Input.GetGroups(6).Select(x => new CustomsDeclarationFormGroupAnswers(x));
            
            var count = answers.Sum(a => CustomsDeclarationFormAnswers.Questions
                .Count(x => a.Answers.All(y => y.Answer(x))));

            Console.Write(count);
        }
    }
}