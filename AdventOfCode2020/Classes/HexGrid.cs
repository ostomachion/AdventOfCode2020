using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class HexGrid
    {
        public HashSet<(int X, int Y)> BlackTiles { get; } = new();

        public static (int X, int Y) GetCoordinate(string directions)
        {
            directions = directions
                .Replace("ne", "n")
                .Replace("sw", "s")
                .Replace("nw", "a")
                .Replace("se", "z");

            var x = 0;
            var y = 0;
            foreach (var c in directions)
            {
                (x, y) = c switch
                {
                    'n' => (x, y - 1),
                    's' => (x, y + 1),
                    'e' => (x + 1, y),
                    'w' => (x - 1, y),
                    'a' => (x - 1, y - 1),
                    'z' => (x + 1, y + 1),
                    _ => throw new FormatException()
                };
            }

            return (x, y);
        }

        public void Flip(int x, int y)
        {
            if (BlackTiles.Contains((x, y)))
                BlackTiles.Remove((x, y));
            else
                BlackTiles.Add((x, y));
        }

        public void Update()
        {
            HashSet<(int X, int Y)> flipped = new();
            var minX = BlackTiles.Min(p => p.X);
            var minY = BlackTiles.Min(p => p.Y);
            var maxX = BlackTiles.Max(p => p.X);
            var maxY = BlackTiles.Max(p => p.Y);
            for (var y = minY - 1; y <= maxY + 1; y++)
            {
                for (var x = minX - 1; x <= maxX + 1; x++)
                {
                    var neighbors = CountNeighbors(x, y);
                    if (BlackTiles.Contains((x, y)))
                    {
                        if (neighbors == 0 || neighbors > 2)
                            flipped.Add((x, y));
                    }
                    else
                    {
                        if (neighbors == 2)
                            flipped.Add((x, y));
                    }
                }
            }
            foreach (var (x, y) in flipped)
                Flip(x, y);
        }

        public int CountNeighbors(int x, int y)
        {
            return new (int X, int Y)[] {
                (0, -1),
                (0, 1),
                (1, 0),
                (-1, 0),
                (-1, -1),
                (1, 1)
            }.Count(p => BlackTiles.Contains((x + p.X, y + p.Y)));
        }
    }
}