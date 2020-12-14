using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day14Obj
    {
        public Dictionary<int, long> Memory = new();
        public Inst14[] Value { get; set; }
        public Dictionary<int, int> Mask { get; set; }

        public static Day14Obj Parse(string[] text)
        {

            return new Day14Obj { Value = text.Select(Inst14.Parse).ToArray() };
        }

        public void Run()
        {
            foreach (var inst in Value)
            {
                if (inst.Mask)
                {
                    Mask = inst.MaskValue;
                }
                else
                {
                    if (!Memory.ContainsKey(inst.Index))
                        Memory.Add(inst.Index, 0);
                    Memory[inst.Index] = ApplyMask(inst.Value);
                }
            }
        }

        public long Sum()
        {
            return Memory.Values.Sum();
        }

        public long ApplyMask(long value)
        {
            var bin = Convert.ToString(value, 2).PadLeft(36, '0').Reverse().ToArray();
            foreach (var i in Mask.Keys)
            {
                bin[i] = Mask[i].ToString()[0];
            }
            var test = new string(bin.Reverse().ToArray());
            return Convert.ToInt64(new string(bin.Reverse().ToArray()), 2);
        }
    }

    public class Inst14
    {
        public bool Mask;
        public int Index;
        public long Value;
        public Dictionary<int, int> MaskValue;

        public Inst14(bool mask, int index, long value)
        {
            Mask = mask;
            Index = index;
            Value = value;
        }

        public Inst14(bool mask, int index, long value, Dictionary<int, int> maskValue) : this(mask, index, value)
        {
            MaskValue = maskValue;
        }

        public static Inst14 Parse(string text)
        {
            if (text.StartsWith("mask"))
            {
                Dictionary<int, int> maskValue = new();
                var mask = text.Substring("mask = ".Length);
                for (int i = 0; i < mask.Length; i++)
                {
                    if (mask[i] == '0')
                    {
                        maskValue.Add(36 - i - 1, 0);
                    }
                    else if (mask[i] == '1')
                    {
                        maskValue.Add(36 - i - 1, 1);
                    }
                }
                return new Inst14(true, 0, 0, maskValue);
            }
            else
            {
                var match = Regex.Match(text, @"^mem\[(?<index>\d+)\] = (?<value>\d+)$");
                var index = match.Groups["index"].Value;
                var value = match.Groups["value"].Value;
                return new Inst14(false, int.Parse(match.Groups["index"].Value), long.Parse(match.Groups["value"].Value));
            }
        }
    }
}