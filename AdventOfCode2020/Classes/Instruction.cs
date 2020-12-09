using System;

namespace AdventOfCode2020
{
    public enum InstructionCode { Acc, Jmp, Nop }

    public struct Instruction
    {
        public InstructionCode Code { get; }
        public int Value { get; }

        public Instruction(string source)
        {
            throw new NotImplementedException();
        }
    }
}