using System;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020
{
    public class SeaPortComputer
    {
        public SeaPortMask Mask { get; private set; } = new SeaPortMask();
        public Dictionary<ulong, ulong> Memory { get; } = new();

        public void Run(SeaPortProgram program, bool v2)
        {
            foreach (var instruction in program.Instructions)
            {
                Run(instruction, v2);
            }
        }

        public void Run(SeaPortInstruction instruction, bool v2)
        {
            if (instruction is SeaPortMaskInstruction mask)
            {
                Mask = mask.Mask;
            }
            else if (instruction is SeaPortMemInstruction mem)
            {
                if (v2)
                {
                    var indexMask = Mask.ApplyV2(mem.Index);
                    foreach (var index in indexMask.GetValues())
                    {
                        if (!Memory.ContainsKey(index))
                            Memory.Add(index, 0);
                        Memory[index] = mem.Value;
                    }
                }
                else
                {
                    if (!Memory.ContainsKey(mem.Index))
                        Memory.Add(mem.Index, 0);
                    Memory[mem.Index] = Mask.Apply(mem.Value);
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}