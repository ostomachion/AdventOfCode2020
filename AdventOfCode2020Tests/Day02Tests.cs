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
            var results = list.Select(x => x.Policy.Check(x.Password));

            // Then
            Assert.Equal(results, new[] { true, false, true });
        }

        [Fact]
        public void Part2Test()
        {
            throw new NotImplementedException();
        }
    }
}
