using System.IO;

namespace AdventOfCode2020
{
    public static class Input
    {
        public static string Get(int day) => File.ReadAllText(Path.Combine("Input", $"Day{day.ToString().PadLeft(2, '0')}.txt"));
    }
}
