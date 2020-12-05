using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class BoardingPass
    {
        public string Specification { get; }
        public int Row { get; }
        public int Column { get; }
        public int SeatId => Row * 8 + Column;

        public BoardingPass(string specification)
        {
            Specification = specification ?? throw new ArgumentNullException(nameof(specification));
            if (!Regex.IsMatch(specification, @"^[BF]{7}[LR]{3}$"))
                throw new FormatException("Invalid specification.");

            Row = Convert.ToInt32(specification.Substring(0, 7).Replace("F", "0").Replace("B", "1"), 2);
            Column = Convert.ToInt32(specification.Substring(7, 3).Replace("L", "0").Replace("R", "1"), 2);
        }

        public BoardingPass(int row, int column)
        {
            throw new NotImplementedException();
        }
    }
}