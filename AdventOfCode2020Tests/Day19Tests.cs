using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day19Tests
    {
        [Theory]
        [InlineData("aab", true)]
        [InlineData("aba", true)]
        [InlineData("", false)]
        [InlineData("a", false)]
        [InlineData("b", false)]
        [InlineData("aa", false)]
        [InlineData("ab", false)]
        [InlineData("ba", false)]
        [InlineData("bb", false)]
        [InlineData("aaa", false)]
        [InlineData("abb", false)]
        [InlineData("baa", false)]
        [InlineData("bab", false)]
        [InlineData("bba", false)]
        [InlineData("bbb", false)]
        [InlineData("abaa", false)]
        [InlineData("abab", false)]
        [InlineData("aaba", false)]
        [InlineData("aabb", false)]
        [InlineData("abx", false)]
        [InlineData("xyz", false)]
        public void Part1SimpleTest(string input, bool match)
        {
            // Given
            var ruleSet = MessageRuleSet.Parse(Input.Get(19, "Simple"));

            // When
            var actual = ruleSet[0].Matches(input);

            // Then
            Assert.Equal(match, actual);
        }

        [Theory]
        [InlineData("aaaabb", true)]
        [InlineData("aaabab", true)]
        [InlineData("abbabb", true)]
        [InlineData("abbbab", true)]
        [InlineData("aabaab", true)]
        [InlineData("aabbbb", true)]
        [InlineData("abaaab", true)]
        [InlineData("ababbb", true)]
        [InlineData("aaaaba", false)]
        [InlineData("aaaaaa", false)]
        [InlineData("aaaaab", false)]
        [InlineData("baaabb", false)]
        [InlineData("aabbab", false)]
        [InlineData("aaaaxx", false)]
        [InlineData("", false)]
        [InlineData("a", false)]
        [InlineData("aa", false)]
        [InlineData("aaa", false)]
        [InlineData("aaaa", false)]
        [InlineData("aaaaa", false)]
        [InlineData("aaaabba", false)]
        [InlineData("aaaabbb", false)]
        [InlineData("aaaaabb", false)]
        [InlineData("baaaabb", false)]
        public void Part1InterestingTest(string input, bool match)
        {
            // Given
            var ruleSet = MessageRuleSet.Parse(Input.Get(19, "Interesting"));

            // When
            var actual = ruleSet[0].Matches(input);

            // Then
            Assert.Equal(match, actual);
        }

        [Fact]
        public void Part1Test()
        {
            // Given
            var groups = Input.GetGroups(19, "Part1");
            var ruleSet = MessageRuleSet.Parse(groups[0]);
            var inputs = groups[1].Split('\n');

            // When
            var count = inputs.Count(ruleSet[0].Matches);

            // Then
            Assert.Equal(2, count);
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var groups = Input.GetGroups(19, "Part2");
            var ruleSet = MessageRuleSet.Parse(groups[0]);
            var inputs = groups[1].Split('\n');

            // When
            var oldCount = inputs.Count(ruleSet[0].Matches);

            ruleSet[8] = MessageRule.Parse("42 | 42 8");
            ruleSet[11] = MessageRule.Parse("42 31 | 42 11 31");
            var newCount = inputs.Count(ruleSet[0].Matches);

            // Then
            Assert.Equal(3, oldCount);
            Assert.Equal(12, newCount);
        }
    }
}
