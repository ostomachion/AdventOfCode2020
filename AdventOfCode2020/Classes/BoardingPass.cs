using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    /// <summary>
    /// Represents a boarding pass containing seating information.
    /// </summary>
    /// <remarks>Used with <see cref="Day05"/>.</remarks>
    public class BoardingPass
    {
        /// <summary>
        /// The string on the boarding pass that encodes the seating
        /// information using "binary space partitioning".
        /// </summary>
        public string Specification { get; }

        /// <summary>
        /// The row number, from 0 to 127.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// The column number, from 0 to 7.
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// The seat id, determined uniquely by the row and column numbers.
        /// </summary>
        public int SeatId => Row * 8 + Column;

        /// <summary>
        /// Creates an instance of <see cref="BoaringPass"/> from a boarding
        /// pass specification string.
        /// </summary>
        /// <param name="specification">The specificatoin string to parse.</param>
        public BoardingPass(string specification)
        {
            Specification = specification ?? throw new ArgumentNullException(nameof(specification));
            if (!Regex.IsMatch(specification, @"^[BF]{7}[LR]{3}$"))
                throw new FormatException("Invalid specification.");

            Row = Convert.ToInt32(specification.Substring(0, 7).Replace("F", "0").Replace("B", "1"), 2);
            Column = Convert.ToInt32(specification.Substring(7, 3).Replace("L", "0").Replace("R", "1"), 2);
        }
    }
}