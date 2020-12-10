using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day09Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var cypher = new XmasCypher(Input.GetLines(9).Select(BigInteger.Parse)) { PreambleSize = 5 };

            // When
            var nonSumNumber = cypher.FindNonSumNumber();

            // Then
            Assert.Equal(127, nonSumNumber);
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var cypher = new XmasCypher(Input.GetLines(9).Select(BigInteger.Parse)) { PreambleSize = 5 };

            // When
            var key = cypher.FindKey(cypher.FindNonSumNumber()).ToArray();

            // Then
            Assert.Equal(15, key.Min());
            Assert.Equal(47, key.Max());
        }
    }
}
