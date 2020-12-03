using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public enum TobogganMapTile
    {
        Empty,
        Tree,
    }

    public class TobogganMap
    {
        public static readonly Dictionary<char, TobogganMapTile> Characters = new Dictionary<char, TobogganMapTile>
        {
            ['.'] = TobogganMapTile.Empty,
            ['#'] = TobogganMapTile.Tree,
        };

        private TobogganMapTile[,] map;

        public TobogganMapTile this[int x, int y] => this.map[x % this.map.GetLength(0), y];

        public TobogganMap(TobogganMapTile[,] map)
        {
            this.map = map;
        }

        public TobogganMapTile[] GetPath(int dx)
        {
            return Enumerable.Range(0, this.map.GetLength(1))
                .Select(i => this[i * dx, i])
                .ToArray();
        }

        public static TobogganMap Parse(string input)
        {
            var lines = input.Split('\n');
            var widths = lines.Select(x => x.Length);
            if (widths.Distinct().Count() != 1)
                throw new ArgumentException(nameof(input));
            var width = widths.First();

            TobogganMapTile[,] trees = new TobogganMapTile[width, lines.Length];
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (Characters.TryGetValue(lines[y][x], out TobogganMapTile tile))
                    {
                        trees[x, y] = tile;
                    }
                    else
                    {
                        throw new ArgumentException(nameof(input));
                    }
                }
            }

            return new TobogganMap(trees);
        }
    }
}