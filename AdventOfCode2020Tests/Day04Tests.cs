using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;

namespace AdventOfCode2020Tests
{
    public class Day04Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var passports = Input.GetGroups(4).Select(PassportData.Parse);

            // When
            var status = passports.Select(x => x.IsComplete);

            // Then
            Assert.Equal(new[] { true, false, true, false }, status);
        }

        [Theory]
        [InlineData("2002", true)]
        [InlineData("2003", false)]
        public void Part2BirthYearTest(string input, bool isValid)
        {
            Assert.Equal(isValid, Passport.TryParseBirthYear(input, out _));
        }

        [Theory]
        [InlineData("60in", true)]
        [InlineData("190cm", true)]
        [InlineData("190in", false)]
        [InlineData("190", false)]
        public void Part2HeightTest(string input, bool isValid)
        {
            Assert.Equal(isValid, Passport.TryParseHeight(input, out _));
        }

        [Theory]
        [InlineData("#123abc", true)]
        [InlineData("#123abz", false)]
        [InlineData("123abc", false)]
        public void Part2HairColorTest(string input, bool isValid)
        {
            Assert.Equal(isValid, Passport.TryParseHairColor(input, out _));
        }

        [Theory]
        [InlineData("brn", true)]
        [InlineData("wat", false)]
        public void Part2EyeColorTest(string input, bool isValid)
        {
            Assert.Equal(isValid, Passport.TryParseEyeColor(input, out _));
        }

        [Theory]
        [InlineData("000000001", true)]
        [InlineData("0123456789", false)]
        public void Part2PassportIdTest(string input, bool isValid)
        {
            Assert.Equal(isValid, Passport.TryParsePassportId(input, out _));
        }

        [Fact]
        public void Part2InvalidTest() {
            // Given
            var data = Input.GetGroups(4, "Invalid").Select(PassportData.Parse);

            // Then
            Assert.All(data, item => Assert.False(item.IsValidPassport(out _)));
        }

        [Fact]
        public void Part2ValidTest() {
            // Given
            var data = Input.GetGroups(4, "Valid").Select(PassportData.Parse);

            // Then
            Assert.All(data, item => Assert.True(item.IsValidPassport(out _)));
        }
    }
}
