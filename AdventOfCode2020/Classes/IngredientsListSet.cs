using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class IngredientsListSet
    {
        public IEnumerable<IngredientsList> Value { get; }

        public IngredientsListSet(IEnumerable<IngredientsList> value)
        {
            Value = value;
        }

        public static IngredientsListSet Parse(string text)
        {
            return new IngredientsListSet(text.Split('\n').Select(IngredientsList.Parse));
        }

        public Dictionary<string, string> FindAllergens()
        {
            Dictionary<string, List<string>> candidates = new();
            foreach (var list in Value)
            {
                foreach (var allergen in list.Allergens)
                {
                    if (candidates.ContainsKey(allergen))
                    {
                        candidates[allergen] = candidates[allergen].Intersect(list.Ingredients).ToList();
                    }
                    else
                    {
                        candidates.Add(allergen, list.Ingredients.ToList());
                    }
                }
            }

            List<string> done = new ();
            while (candidates.Keys.FirstOrDefault(x => !done.Contains(x) && candidates[x].Count == 1) is string allergen)
            {
                var name = candidates[allergen].Single();
                foreach (var key in candidates.Keys.Except(new[] { allergen }))
                {
                    candidates[key].Remove(name);
                }
                done.Add(allergen);
            }

            return candidates.ToDictionary(x => x.Key, x => x.Value.Single());
        }
    }
}