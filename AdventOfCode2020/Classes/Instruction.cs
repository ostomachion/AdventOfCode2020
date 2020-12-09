using System;

namespace AdventOfCode2020
{
    public enum InstructionCode { Acc, Jmp, Nop }

    public struct Instruction
    {
        public InstructionCode Code { get; }
        public int Value { get; }

        public Instruction(InstructionCode code, int value)
        {
            Code = code;
            Value = value;
        }

        public static Instruction Parse(string source)
        {
            var parts = source.Split(new[] { ' ' }, 2);
            var code = parts[0] switch
            {
                "acc" => InstructionCode.Acc,
                "jmp" => InstructionCode.Jmp,
                "nop" => InstructionCode.Nop,
                var codeString => throw new FormatException($"Unknown program code '{codeString}'.")
            };
            if (!int.TryParse(parts[1], out int value))
                throw new FormatException($"Invalid argument '{parts[1]}'.");
            return new(code, value);
        }
    }
}