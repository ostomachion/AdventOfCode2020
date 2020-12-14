using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day14Tests
    {
        [Theory]
        [InlineData(11, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 73)]
        [InlineData(101, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 101)]
        [InlineData(0, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 64)]
        public void MaskV1Test(ulong value, string maskString, ulong result)
        {
            // Given
            var mask = new SeaPortMask(maskString);

            // When
            var actual = mask.Apply(value);

            // Then
            Assert.Equal(result, actual);
        }

        [Fact]
        public void Part1Test()
        {
            // Given
            var computer = new SeaPortComputer();
            var program = SeaPortProgram.Parse(Input.Get(14, "Part1"));

            // When
            computer.Run(program, false);

            //Then
            Assert.Equal(165, Day14.Sum(computer));
        }

        [Theory]
        [InlineData(42, "000000000000000000000000000000X1001X", "000000000000000000000000000000X1101X")]
        [InlineData(26, "00000000000000000000000000000000X0XX", "00000000000000000000000000000001X0XX")]
        public void MaskV2Test(ulong value, string maskString, string result)
        {
            // Given
            var mask = new SeaPortMask(maskString);

            // When
            var actual = mask.ApplyV2(value);

            // Then
            Assert.Equal(new SeaPortMask(result), actual);
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var computer = new SeaPortComputer();
            var program = SeaPortProgram.Parse(Input.Get(14, "Part2"));

            // When
            computer.Run(program, true);

            //Then
            Assert.Equal(208, Day14.Sum(computer));
        }
    }
}
