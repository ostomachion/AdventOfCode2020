using System.Reflection.Metadata;
using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day22Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var game = CombatGame.Parse(Input.Get(22));

            // When
            game.Play();

            // Then
            Assert.Equal(306, CombatGame.GetScore(game.Player1Deck) + CombatGame.GetScore(game.Player2Deck));
        }

        [Fact]
        public void Part2Test()
        {
            // Given
            var game = CombatGame.Parse(Input.Get(22));

            // When
            game.PlayRecursive();

            // Then
            Assert.Equal(291, CombatGame.GetScore(game.Player1Deck) + CombatGame.GetScore(game.Player2Deck));
        }
    }
}
