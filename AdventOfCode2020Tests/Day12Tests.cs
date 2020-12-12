using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2020Tests
{
    public class Day12Tests
    {
        [Fact]
        public void Part1Test()
        {
            // Given
            var route = Route.Parse(Input.Get(12));
            var ship = new Ship();

            // When
            ship.FollowRouteAbsolute(route);

            // Then
            Assert.Equal(17, ship.X);
            Assert.Equal(-8, ship.Y);
        }

        [Fact]
        public void PartTest()
        {
            // Given
            var route = Route.Parse(Input.Get(12));
            var ship = new Ship();

            // When
            ship.FollowRoute(route);

            // Then
            Assert.Equal(214, ship.X);
            Assert.Equal(-72, ship.Y);
            Assert.Equal(4, ship.WaypointX);
            Assert.Equal(-10, ship.WaypointY);
        }
    }
}
