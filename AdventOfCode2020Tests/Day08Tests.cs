using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020Tests
{
    public class Day08Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var program = new HandheldProgram(Input.Get(8));
            var computer = new HandheldComputer(program);
            var accumulator = computer.Accumulator;

            var visited = new HashSet<int>();

            // When
            while (!visited.Contains(computer.ProgramCounter))
            {
                accumulator = computer.Accumulator;
                visited.Add(computer.ProgramCounter);
                computer.Step();
            }

            // Then
            Assert.Equal(5, accumulator);
        }
    }
}
