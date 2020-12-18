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
            var expressions = Input.GetLines(18).Select(x => new NewMathExpression(x));

            // When
            var answers = expressions.Select(x => x.Evaluate());

            // Then
            Assert.Equal(new [] { 71, 51, 26, 437, 12240, 13632 }, answers);
        }
    }
}
