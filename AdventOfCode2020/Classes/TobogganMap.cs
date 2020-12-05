using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    /// <summary>
    /// Represents a map of trees. The map repeats to the right forever.
    /// </summary>
    /// <remarks>Used with <see cref="Day03"/>.</remarks>
    public class TobogganMap
    {
        /// <summary>
        /// A mapping from characters used in the text representation of the
        /// map to a <see cref="TobogganMapTile"/>.
        /// </summary>
        public static readonly Dictionary<char, TobogganMapTile> Characters = new()
        {
            ['.'] = TobogganMapTile.Empty,
            ['#'] = TobogganMapTile.Tree,
        };

        private readonly TobogganMapTile[,] map;

        /// <summary>
        /// Returns the <see cref="TobogganMapTile"/> located a cordinate
        /// (<paramref name="x"/>, <paramref name="y"/>). This accounts for the
        /// map looping forever to the right.
        /// </summary>
        /// <returns>
        /// The <see cref="TobogganMapTile"/> located a cordinate
        /// (<paramref name="x"/>, <paramref name="y"/>).
        /// </returns>
        public TobogganMapTile this[int x, int y] => this.map[x % this.map.GetLength(0), y];

        /// <summary>
        /// Creates an instance of <see cref="TobogganMap"/>.
        /// </summary>
        /// <param name="map">A grid of <see cref="TobogganMapTile"/> objects.</param>
        public TobogganMap(TobogganMapTile[,] map)
        {
            this.map = map;
        }

        /// <summary>
        /// Returns an array of tiles encountered by starting at (0,0) and
        /// travelling <paramref name="dx"/> tile right and
        /// <paramref name="dy"/> tiles down until reaching the bottom of the
        /// map.
        /// </summary>
        /// <param name="dx">The number of tiles to move right each step.</param>
        /// <param name="dy">The number of tiles to move right each step.</param>
        /// <returns></returns>
        public TobogganMapTile[] GetPath(int dx, int dy)
        {
            if (dx < 0)
                throw new ArgumentException($"{nameof(dx)} must be non-negative.", nameof(dx));
            if (dy <= 0)
                throw new ArgumentException($"{nameof(dy)} must be positive.", nameof(dy));

            return Enumerable.Range(0, this.map.GetLength(1) / dy)
                .Select(i => this[i * dx, i * dy])
                .ToArray();
        }

        /// <summary>
        /// Creates an instance of <see cref="TobogganMap"/> from a text
        /// representation. The characters used in the map are mapped to
        /// <see cref="TobogganMapTile"/> objects using
        /// <see cref="Characters"/>.
        /// </summary>
        /// <param name="input">A text representation of the map.</param>
        /// <returns>A new <see cref="TobogganMap"/> based on the input.</returns>
        public static TobogganMap Parse(string input)
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input));

            if (input is "")
                throw new ArgumentException("Input must not be empty.", nameof(input));

            var lines = input.Split('\n');
            var widths = lines.Select(x => x.Length);
            if (widths.Distinct().Count() != 1)
                throw new FormatException("All lines must be the same length.");
            var width = widths.First();

            if (width == 0)
                throw new FormatException("Map width must be greater than 0.");

            var trees = new TobogganMapTile[width, lines.Length];
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var c = lines[y][x];
                    if (Characters.TryGetValue(c, out TobogganMapTile tile))
                    {
                        trees[x, y] = tile;
                    }
                    else
                    {
                        throw new FormatException($"Unexpected character '{c}' at line {y} position {x}.");
                    }
                }
            }

            return new TobogganMap(trees);
        }
    }
}