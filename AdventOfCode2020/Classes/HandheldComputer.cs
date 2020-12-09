using System;

namespace AdventOfCode2020
{
    public class HandheldComputer
    {
        public HandheldProgram Program { get; }
        public int ProgramCounter { get; private set; }
        public int Accumulator { get; private set; }

        public void Reset() => Accumulator = 0;

        public HandheldComputer(HandheldProgram program)
        {
            Program = program;
        }

        public void Step()
        {
            throw new NotImplementedException();
        }
    }
}