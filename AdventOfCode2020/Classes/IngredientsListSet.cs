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
            throw new NotImplementedException();
        }
    }
}