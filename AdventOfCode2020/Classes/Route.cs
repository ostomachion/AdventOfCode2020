using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }
    }
}