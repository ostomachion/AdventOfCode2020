using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class SeaPortProgram
    {
        public IEnumerable<SeaPortInstruction> Instructions;

        public SeaPortProgram(IEnumerable<SeaPortInstruction> instructions)
        {
            Instructions = instructions;
        }

        public static SeaPortProgram Parse(string source)
        {
            return new SeaPortProgram(source.Split("\n").Select(SeaPortInstruction.Parse));
        }
    }
}