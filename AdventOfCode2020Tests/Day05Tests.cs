using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;

namespace AdventOfCode2020Tests
{
    public class Day05Tests
    {
        [Theory]
        [InlineData("BFFFBBFRRR", 70, 7, 567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        public void Part1Test(string specification, int row, int column, int seatId)
        {
            // Given
            var boardingPass = new BoardingPass(specification);

            // Then
            Assert.Equal(row, boardingPass.Row);
            Assert.Equal(column, boardingPass.Column);
            Assert.Equal(seatId, boardingPass.SeatId);
        }
    }
}
