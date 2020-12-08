using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;

namespace AdventOfCode2020Tests
{
    public class Day07Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var rules = new LuggageRuleSet(Input.GetLines(7).Select(x => new LuggageRule(x)));

            // When
            var colors = rules.Rules.Select(x => x.Color);
            var canHoldShinyGold = colors.Where(x => rules.CanEventuallyContain(x, "shiny gold"))
                .OrderBy(x => x);

            // Then
            Assert.Equal(new [] { "bright white", "dark orange", "light red", "muted yellow" }, canHoldShinyGold);
        }
    }
}
