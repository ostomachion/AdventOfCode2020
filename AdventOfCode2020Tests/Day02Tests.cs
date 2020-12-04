using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;

namespace AdventOfCode2020Tests
{
    public class Day02Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var list = Input.GetLines(2).Select(PasswordLine.Parse);

            // When
            var results = list.Select(x => x.Policy.OldSystemCheck(x.Password));

            // Then
            Assert.Equal(new[] { true, false, true }, results);
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var list = Input.GetLines(2).Select(PasswordLine.Parse);

            // When
            var results = list.Select(x => x.Policy.NewSystemCheck(x.Password));

            // Then
            Assert.Equal(new[] { true, false, false }, results);
        }
    }
}
