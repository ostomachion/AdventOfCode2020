using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class ImageTile
    {
        public int Id { get; }
        public bool[,] Value { get; }

        public ImageTile(int id, bool[,] value)
        {
            Id = id;
            Value = value;
        }

        public static ImageTile Parse(string text)
        {
            throw new NotImplementedException();
        }

        public static ImageTile[,] Arrange(IEnumerable<ImageTile> tiles)
        {
            throw new NotImplementedException();
        }
    }
}