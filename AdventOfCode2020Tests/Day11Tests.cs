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
            var step1 = layout.StepPart1();
            var step2 = step1.StepPart1();
            var step3 = step2.StepPart1();
            var step4 = step3.StepPart1();
            var step5 = step4.StepPart1();
            var stable = layout.StabalizePart1();
            var count = stable.Count(SeatLayoutTile.OccupiedSeat);

            // Then
            Assert.Equal(step1, SeatLayout.Parse(Input.Get(11, "Part1Step1")));
            Assert.Equal(step2, SeatLayout.Parse(Input.Get(11, "Part1Step2")));
            Assert.Equal(step3, SeatLayout.Parse(Input.Get(11, "Part1Step3")));
            Assert.Equal(step4, SeatLayout.Parse(Input.Get(11, "Part1Step4")));
            Assert.Equal(step5, SeatLayout.Parse(Input.Get(11, "Part1Step5")));
            Assert.Equal(step5, step5.StepPart1());
            Assert.Equal(step5, stable);
            Assert.Equal(37, count);
        }

        [Theory]
        [InlineData(1, 3, 4, 8)]
        [InlineData(2, 1, 1, 0)]
        [InlineData(3, 3, 3, 0)]
        public void Part2CountTest(int i, int x, int y, int count)
        {
            // Given
            var layout = SeatLayout.Parse(Input.Get(11, $"Part2Count{i}"));

            // When
            var actual = layout.CountAdjacentPart2(x, y);

            // Then
            Assert.Equal(count, actual);
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var layout = SeatLayout.Parse(Input.Get(11));

            // When
            var step1 = layout.StepPart2();
            var step2 = step1.StepPart2();
            var step3 = step2.StepPart2();
            var step4 = step3.StepPart2();
            var step5 = step4.StepPart2();
            var step6 = step5.StepPart2();
            var stable = layout.StabalizePart2();
            var count = stable.Count(SeatLayoutTile.OccupiedSeat);

            // Then
            Assert.Equal(step1, SeatLayout.Parse(Input.Get(11, "Part2Step1")));
            Assert.Equal(step2, SeatLayout.Parse(Input.Get(11, "Part2Step2")));
            Assert.Equal(step3, SeatLayout.Parse(Input.Get(11, "Part2Step3")));
            Assert.Equal(step4, SeatLayout.Parse(Input.Get(11, "Part2Step4")));
            Assert.Equal(step5, SeatLayout.Parse(Input.Get(11, "Part2Step5")));
            Assert.Equal(step6, SeatLayout.Parse(Input.Get(11, "Part2Step6")));
            Assert.Equal(step6, step6.StepPart2());
            Assert.Equal(step6, stable);
            Assert.Equal(26, count);
        }
    }
}
