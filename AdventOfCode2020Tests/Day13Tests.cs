using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day13Tests
    {
        [Fact]
        public void Part1Test()
        {
            
            // Given
            var notes = BusNotes.Parse(Input.Get(13));
            

            // When
            var earliest = notes.GetNextBus();
            var waitTime = notes.GetWaitTime(earliest);

            //Then
            Assert.Equal(59, earliest);
            Assert.Equal(5, waitTime);
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var notes = BusNotes.Parse(Input.Get(13));

            // When
            var t = Day13.Contest(notes.BusIds.ToArray());

            // Then
            Assert.Equal(1068781, t);
        }
    }
}
