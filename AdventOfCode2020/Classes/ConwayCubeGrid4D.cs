using System.Xml.Linq;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class ConwayCubeGrid4D
    {
        public HashSet<(int X, int Y, int Z, int W)> ActiveCells { get; } = new();

        public ConwayCubeGrid4D(HashSet<(int, int, int, int)> activeCells)
        {
            ActiveCells = activeCells;
        }

        public static ConwayCubeGrid4D FromSlice(string text)
        {
            var initial = new HashSet<(int, int, int, int)>();
            var lines = text.Split('\n');
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    if (lines[y][x] == '#')
                    {
                        initial.Add((x, y, 0, 0));
                    }
                }
            }
            return new(initial);
        }

        public void Step()
        {
            var minX = ActiveCells.Min(p => p.X);
            var maxX = ActiveCells.Max(p => p.X);
            var minY = ActiveCells.Min(p => p.Y);
            var maxY = ActiveCells.Max(p => p.Y);
            var minZ = ActiveCells.Min(p => p.Z);
            var maxZ = ActiveCells.Max(p => p.Z);
            var minW = ActiveCells.Min(p => p.W);
            var maxW = ActiveCells.Max(p => p.W);

            var add = new HashSet<(int, int, int, int)>();
            var remove = new HashSet<(int, int, int, int)>();

            for (var z = minZ - 1; z <= maxZ + 1; z++)
            {
                for (var y = minY - 1; y <= maxY + 1; y++)
                {
                    for (var x = minX - 1; x <= maxX + 1; x++)
                    {
                        for (var w = minW - 1; w <= maxW + 1; w++)
                        {
                            var active = ActiveCells.Contains((x, y, z, w));
                            var count = Count(x, y, z, w);
                            if (active && count != 2 && count != 3)
                            {
                                remove.Add((x, y, z, w));
                            }
                            else if (!active && count == 3)
                            {
                                add.Add((x, y, z, w));
                            }
                        }
                    }
                }
            }

            foreach (var p in remove)
                ActiveCells.Remove(p);

            foreach (var p in add)
                ActiveCells.Add(p);
        }

        private int Count(int x, int y, int z, int w)
        {
            var value = 0;
            for (var dz = -1; dz <= 1; dz++)
            {
                for (var dy = -1; dy <= 1; dy++)
                {
                    for (var dx = -1; dx <= 1; dx++)
                    {
                        for (var dw = -1; dw <= 1; dw++)
                        {
                            if (dx == 0 && dy == 0 && dz == 0 && dw == 0)
                                continue;

                            value += ActiveCells.Contains((x + dx, y + dy, z + dz, w + dw)) ? 1 : 0;
                        }
                    }
                }
            }
            return value;
        }
    }
}