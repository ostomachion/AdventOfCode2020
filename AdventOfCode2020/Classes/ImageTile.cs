using System.Text;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace AdventOfCode2020
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class ImageTile
    {
        public int Id { get; }
        public bool[,] Value { get; }
        public int Width => Value.GetLength(0);
        public int Height => Value.GetLength(1);

        public ImageTile(int id, bool[,] value)
        {
            Id = id;
            Value = value;
        }

        public static ImageTile Parse(string text)
        {
            var lines = text.Split('\n');
            var id = int.Parse(Regex.Match(lines[0], @"\d+").Value);
            var data = lines.Skip(1).ToArray();
            var value = new bool[data[0].Length, data.Length];
            for (var i = 0; i < data.Length; i++)
            {
                for (var j = 0; j < data[i].Length; j++)
                {
                    value[i, j] = data[i][j] == '#';
                }
            }
            return new(id, value);
        }

        public override string ToString()
        {
            var value = $"Tile {Id}:\n";
            for (var j = 0; j < Height; j++)
            {
                value += new string(Enumerable.Range(0, Width).Select(i => Value[i, j] ? '#' : '.').ToArray()) + "\n";
            }

            return value;
        }

        private IEnumerable<ImageTile> Orient()
        {
            var item = this;
            for (var i = 0; i < 4; i++)
            {
                yield return item;
                yield return item.Flip();
                item = item.Rotate();
            }
        }

        private ImageTile Flip()
        {
            ImageTile value = new(Id, new bool[Width, Height]);
            for (var j = 0; j < value.Height; j++)
            {
                for (var i = 0; i < value.Width; i++)
                {
                    value.Value[i, j] = Value[j, i];
                }
            }
            return value;
        }

        private ImageTile Rotate()
        {
            ImageTile value = new(Id, new bool[Width, Height]);
            for (var j = 0; j < value.Height; j++)
            {
                for (var i = 0; i < value.Width; i++)
                {
                    value.Value[i, j] = Value[j, Width - i - 1];
                }
            }
            return value;
        }

        private string TopEdge() => new(Enumerable.Range(0, Width).Select(i => Value[i, 0] ? '#' : '.').ToArray());
        private string BottomEdge() => new(Enumerable.Range(0, Width).Select(i => Value[i, Height - 1] ? '#' : '.').ToArray());
        private string LeftEdge() => new(Enumerable.Range(0, Height).Select(i => Value[0, i] ? '#' : '.').ToArray());
        private string RightEdge() => new(Enumerable.Range(0, Height).Select(i => Value[Width - 1, i] ? '#' : '.').ToArray());

        public static ImageTile[,]? Arrange(List<ImageTile> tiles)
        {
            var length = (int)Math.Round(Math.Sqrt(tiles.Count));
            if (length * length != tiles.Count)
                return null;

            ImageTile?[,] value = new ImageTile?[length, length];
            return Arrange(value, tiles)!;

            static ImageTile?[,]? Arrange(ImageTile?[,] placed, IReadOnlyCollection<ImageTile> remaining)
            {
                for (var j = 0; j < placed.GetLength(0); j++)
                {
                    for (var i = 0; i < placed.GetLength(1); i++)
                    {
                        if (placed[i, j] is null)
                        {
                            foreach (var tile in remaining)
                            {
                                foreach (var orientation in tile.Orient())
                                {
                                    var right = i > 0 ? placed[i - 1, j]!.RightEdge() : null;
                                    var left = orientation.LeftEdge();
                                    var bottom = j > 0 ? placed[i, j - 1]!.BottomEdge() : null;
                                    var top = orientation.TopEdge();

                                    if (i > 0 && right != left)
                                        continue;
                                    if (j > 0 && bottom != top)
                                        continue;

                                    placed[i, j] = orientation;
                                    if (Arrange(placed, remaining.Except(new[] { tile }).ToList()) is { } value)
                                        return value;
                                    placed[i, j] = null;
                                }
                            }
                            return null;
                        }
                    }
                }
                return placed;
            }
        }

        public static ImageTile Stitch(ImageTile[,] tiles)
        {
            var tileWidth = tiles[0, 0].Width - 2;
            var tileHeight = tiles[0, 0].Height - 2;
            var gridWidth = tiles.GetLength(0);
            var gridHeight = tiles.GetLength(1);
            var value = new bool[tileWidth * gridWidth, tileHeight * gridHeight];

            for (var j = 0; j < gridWidth; j++)
            {
                for (var i = 0; i < gridHeight; i++)
                {
                    for (var y = 0; y < tileHeight; y++)
                    {
                        for (var x = 0; x < tileWidth; x++)
                        {
                            value[tileWidth * j + x, tileHeight * i + y] = tiles[i, j].Value[x + 1, y + 1];
                        }
                    }
                }
            }

            return new ImageTile(0, value);
        }

        public void CountSeaMonsters()
        {

        }

        public override bool Equals(object? obj)
        {
            return obj is ImageTile tile &&
                   Id == tile.Id; // Close enough.
        }

        public override int GetHashCode()
        {
            return Id;
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}