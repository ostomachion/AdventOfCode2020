using System.Reflection.Metadata;
using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day23Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var game = new CupGame("389125467".Select(c => int.Parse(c.ToString())).ToList());

            Assert.Equal("389125467", game.ToString(3));

            game.Move();
            Assert.Equal("328915467", game.ToString(3));

            game.Move();
            Assert.Equal("325467891", game.ToString(3));

            game.Move();
            Assert.Equal("725891346", game.ToString(7));

            game.Move();
            Assert.Equal("325846791", game.ToString(3));

            game.Move();
            Assert.Equal("925841367", game.ToString(9));

            game.Move();
            Assert.Equal("725841936", game.ToString(7));

            game.Move();
            Assert.Equal("836741925", game.ToString(8));

            game.Move();
            Assert.Equal("741583926", game.ToString(7));

            game.Move();
            Assert.Equal("574183926", game.ToString(5));

            game.Move();
            Assert.Equal("583741926", game.ToString(5));
        }

        [Fact]
        public void Part1LongTest()
        {
            // Given
            var game = new CupGame("389125467".Select(c => int.Parse(c.ToString())).ToList());

            // When
            for (var i = 0; i < 100; i++)
            {
                game.Move();
            }

            // Then
            Assert.Equal("67384529", game.ToString(1)[1..]);
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var list = "389125467".Select(c => int.Parse(c.ToString())).ToList();
            list.AddRange(Enumerable.Range(10, 1000000 - 9));
            Assert.Equal(1000000, list.Max());

            var game = new CupGame(list);

            // When
            for (var i = 0; i < 10000000; i++)
            {
                game.Move();
            }

            // Then
            Assert.True(false);
        }
    }
}
