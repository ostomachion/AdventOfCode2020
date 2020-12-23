using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day22
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/22
        /// </summary>
        public static void Part1()
        {
            var game = CombatGame.Parse(Input.Get(22));
            game.Play();

            Console.WriteLine(CombatGame.GetScore(game.Player1Deck) + CombatGame.GetScore(game.Player2Deck));
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/22#part2
        /// </summary>
        public static void Part2()
        {
            var game = CombatGame.Parse(Input.Get(22));
            game.PlayRecursive();

            Console.WriteLine(CombatGame.GetScore(game.Player1Deck) + CombatGame.GetScore(game.Player2Deck));   
        }
    }
}