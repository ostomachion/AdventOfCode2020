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
            var program = HandheldProgram.Parse(Input.Get(8));
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

        [Fact]
        public void Part2Test()
        {
            // Given
            var program = HandheldProgram.Parse(Input.Get(8));

            for (var i = 0; i < program.Instructions.Count(); i++)
            {
                // When
                var modified = Day08.ModifyProgram(program, i);
                if (modified is null)
                    continue;
                var computer = new HandheldComputer(modified);
                var accumulator = computer.Accumulator;

                var visited = new HashSet<int>();

                while (!computer.IsHalted && !visited.Contains(computer.ProgramCounter))
                {
                    accumulator = computer.Accumulator;
                    visited.Add(computer.ProgramCounter);
                    computer.Step();
                }

                // Then
                if (i == 7)
                {
                    Assert.True(computer.IsHalted);
                    Assert.Equal(8, accumulator);
                }
                else
                {
                    Assert.False(computer.IsHalted);
                }
            }
        }
    }
}
