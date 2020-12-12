using System;

namespace AdventOfCode2020
{
    public struct RouteInstruction
    {
        public char Action { get; init; }
        public int Value { get; init; }

        public RouteInstruction(char action, int value)
        {
            Action = action;
            Value = value;
        }

        public static RouteInstruction Parse(string text)
        {
            throw new NotImplementedException();
        }
    }
}