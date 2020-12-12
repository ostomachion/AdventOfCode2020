using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public struct RouteInstruction
    {
        public RouteAction Action { get; init; }
        public int Value { get; init; }

        private static readonly Dictionary<char, RouteAction> actions = new()
        {
            ['N'] = RouteAction.North,
            ['S'] = RouteAction.South,
            ['E'] = RouteAction.East,
            ['W'] = RouteAction.West,
            ['L'] = RouteAction.Left,
            ['R'] = RouteAction.Right,
            ['F'] = RouteAction.Forward
        };

        public RouteInstruction(RouteAction action, int value)
        {
            Action = action;
            Value = value;
        }

        public static RouteInstruction Parse(string text)
        {
            return new RouteInstruction(actions[text[0]], int.Parse(text[1..]));
        }
    }
}