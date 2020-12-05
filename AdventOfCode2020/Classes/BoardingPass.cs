using System;

namespace AdventOfCode2020
{
    public class BoardingPass
    {
        public string Specification { get; }
        public int Row { get; }
        public int Column { get; }
        public int SeatId => throw new NotImplementedException();

        public BoardingPass(string specification)
        {
            throw new NotImplementedException();
        }

        public BoardingPass(int row, int column)
        {
            throw new NotImplementedException();
        }
    }
}