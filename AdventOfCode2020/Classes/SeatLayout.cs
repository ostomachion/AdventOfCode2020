using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class SeatLayout
    {
        private readonly SeatLayoutTile[,] value;

        public int Width => value.GetLength(0);
        public int Height => value.GetLength(1);

        public SeatLayout(SeatLayoutTile[,] value)
        {
            this.value = value;
        }

        public SeatLayoutTile this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= Width || y < 0 || y >= Height)
                    return SeatLayoutTile.Floor;
                return value[x, y];
            }
        }

        private static readonly Dictionary<char, SeatLayoutTile> tiles = new()
        {
            ['.'] = SeatLayoutTile.Floor,
            ['L'] = SeatLayoutTile.EmptySeat,
            ['#'] = SeatLayoutTile.OccupiedSeat,
        };

        public static SeatLayout Parse(string text)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            var lines = text.Split('\n');
            var value = new SeatLayoutTile[lines[0].Length, lines.Length];
            for (var j = 0; j < lines.Length; j++)
            {
                for (var i = 0; i < lines[j].Length; i++)
                {
                    value[i, j] = tiles[lines[j][i]];
                }
            }

            return new SeatLayout(value);
        }

        public SeatLayout StepPart1()
        {
            var value = new SeatLayoutTile[Width, Height];

            for (var j = 0; j < Height; j++)
            {
                for (var i = 0; i < Width; i++)
                {
                    value[i, j] = this[i, j] == SeatLayoutTile.Floor ? this[i, j] :
                    CountAdjacentPart1(i, j) switch
                    {
                        0 => SeatLayoutTile.OccupiedSeat,
                        >= 4 => SeatLayoutTile.EmptySeat,
                        _ => this[i, j]
                    };
                }
            }

            return new SeatLayout(value);
        }

        public SeatLayout StepPart2()
        {
            var value = new SeatLayoutTile[Width, Height];

            for (var j = 0; j < Height; j++)
            {
                for (var i = 0; i < Width; i++)
                {
                    value[i, j] = this[i, j] == SeatLayoutTile.Floor ? this[i, j] :
                    CountAdjacentPart2(i, j) switch
                    {
                        0 => SeatLayoutTile.OccupiedSeat,
                        >= 5 => SeatLayoutTile.EmptySeat,
                        _ => this[i, j]
                    };
                }
            }

            return new SeatLayout(value);
        }

        public SeatLayout StabalizePart1()
        {
            var next = StepPart1();
            return this == next ? this : next.StabalizePart1();
        }

        public SeatLayout StabalizePart2()
        {
            var next = StepPart2();
            return this == next ? this : next.StabalizePart2();
        }

        public int Count(SeatLayoutTile type) => value.Cast<SeatLayoutTile>().Count(x => x == type);

        private int CountAdjacentPart1(int x, int y)
        {
            return new[] {
                this[x - 1, y - 1],
                this[x, y - 1],
                this[x + 1, y - 1],
                this[x - 1, y],
                this[x + 1, y],
                this[x - 1, y + 1],
                this[x, y + 1],
                this[x + 1, y + 1],
            }.Count(t => t == SeatLayoutTile.OccupiedSeat);
        }

        private int CountAdjacentPart2(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            return obj is SeatLayout layout &&
                   Width == layout.Width &&
                   Height == layout.Height &&
                   value.Cast<SeatLayoutTile>().SequenceEqual(layout.value.Cast<SeatLayoutTile>());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(value, Width, Height);
        }

        public static bool operator ==(SeatLayout left, SeatLayout right) => left.Equals(right);
        public static bool operator !=(SeatLayout left, SeatLayout right) => !(left == right);
    }

    public enum SeatLayoutTile { Floor, EmptySeat, OccupiedSeat }
}
