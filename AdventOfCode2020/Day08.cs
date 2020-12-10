using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day08
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/8
        /// </summary>
        public static void Part1()
        {
            var program = HandheldProgram.Parse(Input.Get(8));
            var computer = new HandheldComputer(program);
            var accumulator = computer.Accumulator;

            var visited = new HashSet<int>();

            while (!visited.Contains(computer.ProgramCounter))
            {
                accumulator = computer.Accumulator;
                visited.Add(computer.ProgramCounter);
                computer.Step();
            }

            Console.WriteLine(accumulator);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/8#part2
        /// </summary>
        public static void Part2()
        {
            var program = HandheldProgram.Parse(Input.Get(8));

            for (var i = 0; i < program.Instructions.Count(); i++)
            {
                var modified = ModifyProgram(program, i);
                if (modified is null)
                    continue;
                var computer = new HandheldComputer(modified);

                var visited = new HashSet<int>();

                while (!computer.IsHalted && !visited.Contains(computer.ProgramCounter))
                {
                    visited.Add(computer.ProgramCounter);
                    computer.Step();
                }

                if (computer.IsHalted)
                {
                    Console.WriteLine(computer.Accumulator);
                    return;
                }
            }
        }

        public static HandheldProgram? ModifyProgram(HandheldProgram program, int line)
        {
            var instruction = program.Instructions.ElementAt(line);
            return instruction.Code switch
            {
                InstructionCode.Acc => null,
                InstructionCode.Jmp => new HandheldProgram(program.Instructions.Take(line)
                    .Concat(new[] { new Instruction(InstructionCode.Nop, instruction.Value) })
                    .Concat(program.Instructions.Skip(line + 1))),
                InstructionCode.Nop => new HandheldProgram(program.Instructions.Take(line)
                    .Concat(new[] { new Instruction(InstructionCode.Jmp, instruction.Value) })
                    .Concat(program.Instructions.Skip(line + 1))),
                _ => throw new NotImplementedException(),
            };
        }
    }
}