using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class IngredientsList
    {
        public IEnumerable<string> Ingredients { get; }
        public IEnumerable<string> Allergens { get; }

        public IngredientsList(IEnumerable<string> ingredients, IEnumerable<string> allergens)
        {
            Ingredients = ingredients;
            Allergens = allergens;
        }

        public static IngredientsList Parse(string text)
        {
            var parts = text.Split(" (contains ", 2);
            return new IngredientsList(parts[0].Split(' '), parts[1].TrimEnd(')').Split(", "));
        }
    }
}