using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day18Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var expressions = Input.GetLines(18);

            // When
            var answers = expressions.Select(NewMathExpression.Evaluate);

            // Then
            Assert.Equal(new BigInteger[] { 71, 51, 26, 437, 12240, 13632 }, answers);
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var expressions = Input.GetLines(18);

            // When
            var answers = expressions.Select(NewMathExpression.EvaluateAdvanced);

            // Then
            Assert.Equal(new BigInteger[] { 231, 51, 46, 1445, 669060, 23340 }, answers);
        }
    }
}
