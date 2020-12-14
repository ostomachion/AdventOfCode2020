using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class SeaPortMemInstruction : SeaPortInstruction
    {
        public ulong Index { get; set; }
        public ulong Value { get; set; }

        public SeaPortMemInstruction(ulong index, ulong value)
        {
            Index = index;
            Value = value;
        }

        public new static SeaPortMemInstruction Parse(string text)
        {
            var match = Regex.Match(text, @"^mem\[(?<index>\d+)\] = (?<value>\d+)$");
            return new SeaPortMemInstruction(ulong.Parse(match.Groups["index"].Value), ulong.Parse(match.Groups["value"].Value));
        }

        public override string ToString() => $"mem[{Index}] = {Value}";
    }
}