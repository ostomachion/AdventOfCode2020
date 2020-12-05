using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    /// <summary>
    /// Represents a height in either centimeters or inches.
    /// </summary>
    /// <remarks>Used with <see cref="Day04"/>.</remarks>
    public struct Height
    {
        private static readonly Regex regex = new($"^(?<value>[0-9]+)(?<unit>cm|in)$");

        /// <summary>
        /// The absolute value of the height, without units.
        /// </summary>
        public int Value { get; init; }

        /// <summary>
        /// The units that the height is measured in.
        /// </summary>
        public HeightUnit Unit { get; init; }

        /// <summary>
        /// Attempts to parse <paramref name="text"/> into a
        /// <see cref="Height"/> object.
        /// </summary>
        /// <param name="text">The string to parse.</param>
        /// <param name="height">The <see cref="Height"/> object, if parsed.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="text"/> contains a valid height;
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool TryParse(string text, out Height height)
        {
            var match = regex.Match(text);
            if (!match.Success)
            {
                height = default;
                return false;
            }

            height = new Height
            {
                Value = int.Parse(match.Groups["value"].Value),
                Unit = match.Groups["unit"].Value switch
                {
                    "cm" => HeightUnit.Centimeter,
                    "in" => HeightUnit.Inch,
                    _ => throw new NotImplementedException()
                }
            };

            return true;
        }
    }
}