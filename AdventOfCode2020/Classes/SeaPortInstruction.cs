namespace AdventOfCode2020
{
    public abstract class SeaPortInstruction
    {
        public static SeaPortInstruction Parse(string text)
        {
            return text.StartsWith("mask") ? SeaPortMaskInstruction.Parse(text) : SeaPortMemInstruction.Parse(text);
        }
    }
}