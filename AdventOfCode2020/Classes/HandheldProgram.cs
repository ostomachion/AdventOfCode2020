using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class HandheldProgram
    {
        public IEnumerable<Instruction> Instructions { get; }

        public HandheldProgram(string source)
        {
            Instructions = source.Split('\n').Select(x => new Instruction(x));
        }
    }
}