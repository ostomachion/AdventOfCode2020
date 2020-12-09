using System;
using System.Linq;

namespace AdventOfCode2020
{
    public class HandheldComputer
    {
        public HandheldProgram Program { get; }
        public int ProgramCounter { get; private set; }
        public int Accumulator { get; private set; }
        public bool IsHalted { get; private set; }

        public HandheldComputer(HandheldProgram program)
        {
            Program = program;
        }

        public void Step()
        {
            if (ProgramCounter == Program.Instructions.Count())
            {
                IsHalted = true;
                return;
            }
            
            if (ProgramCounter < 0 || ProgramCounter >= Program.Instructions.Count())
                throw new InvalidOperationException("Out of bounds.");

            var instruction = Program.Instructions.ElementAt(ProgramCounter);
            switch (instruction.Code)
            {
                case InstructionCode.Acc:
                    Accumulator += instruction.Value;
                    ProgramCounter++;
                    break;
                case InstructionCode.Jmp:
                    ProgramCounter += instruction.Value;
                    break;
                case InstructionCode.Nop:
                    ProgramCounter++;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}