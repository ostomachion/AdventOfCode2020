using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day21
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/21
        /// </summary>
        public static void Part1()
        {
            var notes = IngredientsListSet.Parse(Input.Get(21));
            var names = notes.Value.SelectMany(x => x.Ingredients);

            var allergens = notes.FindAllergens().Values;
            var nonAllergens = names.Except(allergens).ToList();

            var counts = nonAllergens.Select(x => notes.Value.Count(y => y.Ingredients.Contains(x)));

            Console.WriteLine(counts.Sum());
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/21#part2
        /// </summary>
        public static void Part2()
        {
            var notes = IngredientsListSet.Parse(Input.Get(21));
            var allergens = notes.FindAllergens();
            var canonicalDangerousIngredientList = string.Join(',', allergens.OrderBy(x => x.Key).Select(x => x.Value));

            Console.WriteLine(canonicalDangerousIngredientList);
        }
    }
}