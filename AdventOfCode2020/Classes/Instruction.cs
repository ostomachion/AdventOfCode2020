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
            var parts = source.Split(new[] { ' ' }, 2);
            Code = parts[0] switch
            {
                "acc" => InstructionCode.Acc,
                "jmp" => InstructionCode.Jmp,
                "nop" => InstructionCode.Nop,
                var code => throw new FormatException($"Unknown program code '{code}'.")
            };
            if (!int.TryParse(parts[1], out int value))
                throw new FormatException($"Invalid argument '{parts[1]}'.");
            Value = value;
        }
    }
}