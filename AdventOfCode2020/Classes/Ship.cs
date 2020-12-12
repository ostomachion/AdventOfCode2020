using System;

namespace AdventOfCode2020
{
    public class Ship
    {
        public int Orientation { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int WaypointX { get; private set; } = 10;
        public int WaypointY { get; private set; } = 1;

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
                    WaypointY += instruction.Value;
                    break;
                case RouteAction.South:
                    WaypointY -= instruction.Value;
                    break;
                case RouteAction.East:
                    WaypointX += instruction.Value;
                    break;
                case RouteAction.West:
                    WaypointX -= instruction.Value;
                    break;
                case RouteAction.Left:
                    (WaypointX, WaypointY) = instruction.Value switch
                    {
                        90 => (-WaypointY, WaypointX),
                        180 => (-WaypointX, -WaypointY),
                        270 => (WaypointY, -WaypointX),
                        _ => throw new InvalidOperationException()
                    };
                    break;
                case RouteAction.Right:
                    (WaypointX, WaypointY) = instruction.Value switch
                    {
                        90 => (WaypointY, -WaypointX),
                        180 => (-WaypointX, -WaypointY),
                        270 => (-WaypointY, WaypointX),
                        _ => throw new InvalidOperationException()
                    };
                    break;
                case RouteAction.Forward:
                    X += instruction.Value * WaypointX;
                    Y += instruction.Value * WaypointY;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void FollowRouteAbsolute(Route route)
        {
            foreach (var instruction in route.Instructions)
            {
                MoveAbsolute(instruction);
            }
        }

        public void MoveAbsolute(RouteInstruction instruction)
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
                    MoveAbsolute(new RouteInstruction(action, instruction.Value));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}