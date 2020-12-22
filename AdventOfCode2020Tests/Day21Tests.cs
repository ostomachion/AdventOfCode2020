using System.Reflection.Metadata;
using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day21Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var notes = IngredientsListSet.Parse(Input.Get(21));
            var names = notes.Value.SelectMany(x => x.Ingredients);

            // When
            var allergens = notes.FindAllergens().Values;
            var nonAllergens = names.Except(allergens).ToList();

            // Then
            Assert.Equal(4, nonAllergens.Count);
            Assert.Contains("kfcds", nonAllergens);
            Assert.Contains("nhms", nonAllergens);
            Assert.Contains("sbzzf", nonAllergens);
            Assert.Contains("trh", nonAllergens);
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var notes = IngredientsListSet.Parse(Input.Get(21));

            // When
            var allergens = notes.FindAllergens();

            // Then
            Assert.Equal(3, allergens.Count);
            Assert.Contains("mxmxvkd", allergens["dairy"]);
            Assert.Contains("sqjhc", allergens["fish"]);
            Assert.Contains("fvjkl", allergens["soy"]);
        }
    }
}
