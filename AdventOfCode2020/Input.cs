using System.IO;

namespace AdventOfCode2020
{
    /// <summary>
    /// A helper class for getting text from input files.
    /// </summary>
    public static class Input
    {
        /// <summary>
        /// Returns the contents of an input file for a given day.
        /// </summary>
        /// <param name="day">The day to retrieve.</param>
        /// <returns>The contents of the input file for the given day.</returns>
        public static string Get(int day, string? id = null) => File.ReadAllText(Path.Combine("Input", $"Day{day.ToString().PadLeft(2, '0')}{(id is null ? "" : "-" + id)}.txt"));

        /// <summary>
        /// Returns the lines of an input file for a given day.
        /// </summary>
        /// <param name="day">The day to retrieve.</param>
        /// <returns>The lines of the input file for the given day.</returns>
        public static string[] GetLines(int day, string? id = null) => Get(day, id).Split('\n');
    }
}
