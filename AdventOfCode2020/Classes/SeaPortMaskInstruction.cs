namespace AdventOfCode2020
{
    public class SeaPortMaskInstruction : SeaPortInstruction
    {
        public SeaPortMask Mask { get; }

        public SeaPortMaskInstruction(SeaPortMask mask)
        {
            Mask = mask;
        }

        public new static SeaPortMaskInstruction Parse(string text)
        {
            return new SeaPortMaskInstruction(new SeaPortMask(text["mask = ".Length..]));
        }

        public override string ToString() => $"mask = {Mask}";
    }
}