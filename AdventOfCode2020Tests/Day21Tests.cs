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

            // When
            var allergens = notes.FindAllergens();

            // Then
            Assert.Equal(4, allergens.Count);
            Assert.Contains("kfcds", allergens.Keys);
            Assert.Contains("nhms", allergens.Keys);
            Assert.Contains("sbzzf", allergens.Keys);
            Assert.Contains("trh", allergens.Keys);
        }
    }
}
