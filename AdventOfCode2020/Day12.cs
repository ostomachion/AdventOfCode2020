using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day12
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/12
        /// </summary>
        public static void Part1()
        {
            var route = Route.Parse(Input.Get(12));
            var ship = new Ship();

            ship.FollowRouteAbsolute(route);

            Console.WriteLine(Math.Abs(ship.X) + Math.Abs(ship.Y));
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/12#part2
        /// </summary>
        public static void Part2()
        {
            var route = Route.Parse(Input.Get(12));
            var ship = new Ship();

            ship.FollowRoute(route);

            Console.WriteLine(Math.Abs(ship.X) + Math.Abs(ship.Y));
        }
    }
}