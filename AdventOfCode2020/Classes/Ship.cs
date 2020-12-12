using System;

namespace AdventOfCode2020
{
    public class Ship
    {
        public int Orientation { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public void FollowRoute(Route route)
        {
            foreach (var instruction in route.Instructions)
            {
                Move(instruction);
            }
        }

        public void Move(RouteInstruction instruction)
        {
            switch (instruction.Action)
            {
                case RouteAction.North:
                    Y += instruction.Value;
                    break;
                case RouteAction.South:
                    Y -= instruction.Value;
                    break;
                case RouteAction.East:
                    X += instruction.Value;
                    break;
                case RouteAction.West:
                    X -= instruction.Value;
                    break;
                case RouteAction.Left:
                    Orientation = (Orientation + instruction.Value) % 360;
                    break;
                case RouteAction.Right:
                    Orientation = (Orientation - instruction.Value + 360) % 360;
                    break;
                case RouteAction.Forward:
                    var action = Orientation switch
                    {
                        0 => RouteAction.East,
                        90 => RouteAction.North,
                        180 => RouteAction.West,
                        270 => RouteAction.South,
                        _ => throw new InvalidOperationException()
                    };
                    Move(new RouteInstruction(action, instruction.Value));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}