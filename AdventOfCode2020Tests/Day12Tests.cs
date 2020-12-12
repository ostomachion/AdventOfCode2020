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
        public void Part1StepTest()
        {
            // Given
            var ship = new Ship();

            ship.MoveAbsolute(RouteInstruction.Parse("F10"));
            Assert.Equal(10, ship.X);
            Assert.Equal(0, ship.Y);

            ship.MoveAbsolute(RouteInstruction.Parse("N3"));
            Assert.Equal(10, ship.X);
            Assert.Equal(3, ship.Y);

            ship.MoveAbsolute(RouteInstruction.Parse("F7"));
            Assert.Equal(17, ship.X);
            Assert.Equal(3, ship.Y);

            ship.MoveAbsolute(RouteInstruction.Parse("R90"));
            Assert.Equal(17, ship.X);
            Assert.Equal(3, ship.Y);
            Assert.Equal(270, ship.Orientation);

            ship.MoveAbsolute(RouteInstruction.Parse("F11"));
            Assert.Equal(17, ship.X);
            Assert.Equal(-8, ship.Y);
        }

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
        public void Part2StepTest()
        {
            // Given
            var ship = new Ship();

            ship.Move(RouteInstruction.Parse("F10"));
            Assert.Equal(100, ship.X);
            Assert.Equal(10, ship.Y);
            Assert.Equal(10, ship.WaypointX);
            Assert.Equal(1, ship.WaypointY);

            ship.Move(RouteInstruction.Parse("N3"));
            Assert.Equal(100, ship.X);
            Assert.Equal(10, ship.Y);
            Assert.Equal(10, ship.WaypointX);
            Assert.Equal(4, ship.WaypointY);

            ship.Move(RouteInstruction.Parse("F7"));
            Assert.Equal(170, ship.X);
            Assert.Equal(38, ship.Y);
            Assert.Equal(10, ship.WaypointX);
            Assert.Equal(4, ship.WaypointY);

            ship.Move(RouteInstruction.Parse("R90"));
            Assert.Equal(170, ship.X);
            Assert.Equal(38, ship.Y);
            Assert.Equal(4, ship.WaypointX);
            Assert.Equal(-10, ship.WaypointY);

            ship.Move(RouteInstruction.Parse("F11"));
            Assert.Equal(214, ship.X);
            Assert.Equal(-72, ship.Y);
            Assert.Equal(4, ship.WaypointX);
            Assert.Equal(-10, ship.WaypointY);
        }

        [Fact]
        public void Part2Test()
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
