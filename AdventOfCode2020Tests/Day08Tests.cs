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
            var visited = new HashSet<int> { computer.ProgramCounter };

            // When
            do
            {
                computer.Step();
                visited.Add(computer.ProgramCounter);
            } while (!visited.Contains(computer.ProgramCounter));

            // Then
            Assert.Equal(5, computer.Accumulator);
        }
    }
}
