using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day11Tests
    {
        [Fact]
        public void LayoutEqualityReflexive()
        {
            // Given
            var layout1 = SeatLayout.Parse(Input.Get(11));
            var layout2 = SeatLayout.Parse(Input.Get(11));

            // Then
            Assert.True(layout1 == layout2);
        }

        [Fact]
        public void Part1Test()
        {
            // Given
            var layout = SeatLayout.Parse(Input.Get(11));

            // When
            var step1 = layout.Step();
            var step2 = step1.Step();
            var step3 = step2.Step();
            var step4 = step3.Step();
            var step5 = step4.Step();
            var stable = layout.Stabalize();
            var count = stable.Count(SeatLayoutTile.OccupiedSeat);

            // Then
            Assert.Equal(step1, SeatLayout.Parse(Input.Get(11, "Step1")));
            Assert.Equal(step2, SeatLayout.Parse(Input.Get(11, "Step2")));
            Assert.Equal(step3, SeatLayout.Parse(Input.Get(11, "Step3")));
            Assert.Equal(step4, SeatLayout.Parse(Input.Get(11, "Step4")));
            Assert.Equal(step5, SeatLayout.Parse(Input.Get(11, "Step5")));
            Assert.Equal(step5, step5.Step());
            Assert.Equal(step5, stable);
            Assert.Equal(37, count);
        }
    }
}
