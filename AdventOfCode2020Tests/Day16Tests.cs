using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day16Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var notes = TicketNotes.Parse(Input.Get(16, "Part1"));

            // When
            var values = notes.FindImpossibleValues();

            // Then
            Assert.Equal(71, values.Sum());
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var notes = TicketNotes.Parse(Input.Get(16, "Part2"));

            // When
            var order = notes.GetFieldOrder();

            // Then
            Assert.Equal(new[] { "row", "class", "seat" }, order);
        }
    }
}
