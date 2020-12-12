using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public struct Route
    {
        public IEnumerable<RouteInstruction> Instructions { get; }

        public Route(IEnumerable<RouteInstruction> instructions)
        {
            Instructions = instructions;
        }

        public static Route Parse(string text)
        {
            return new Route(text.Split("\n").Select(RouteInstruction.Parse));
        }
    }
}