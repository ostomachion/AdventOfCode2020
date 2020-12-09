using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class HandheldProgram
    {
        public IEnumerable<Instruction> Instructions { get; }

        public HandheldProgram(IEnumerable<Instruction> instructions)
        {
            Instructions = instructions;
        }

        public static HandheldProgram Parse(string source)
        {
            return new(source.Split('\n').Select(x => Instruction.Parse(x)));
        }
    }
}