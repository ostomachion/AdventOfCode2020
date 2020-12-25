using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections;

namespace AdventOfCode2020
{
    public class CupGame
    {
        public int Current { get; private set; }
        public List<int> Cups { get; }

        public CupGame(List<int> cups)
        {
            Cups = cups;
            Current = cups[0];
        }

        private int Index(int i) => i % Cups.Count;

        public void Move()
        {
            var removed = Cups.Skip(1).Take(3).ToList();
            Cups.RemoveRange(1, 3);
            
            var destination = GetDestination();
            Cups.InsertRange(Cups.IndexOf(destination) + 1, removed);

            var index = Cups.IndexOf(Current) + 1;
            Current = Cups[index];
            var pre = Cups.Take(index).ToList();
            Cups.RemoveRange(0, index);
            Cups.AddRange(pre);
        }

        public override string ToString() => ToString(1);

        public string ToString(int start)
        {
            var value = string.Join("", Cups.Select(x => x.ToString()));
            var index = value.IndexOf(start.ToString());
            return value[index..] + value[0..index];
        }

        public int GetDestination()
        {
            var label = Current - 1;
            while (!Cups.Contains(label))
            {
                label--;
                if (label < Cups.Min())
                    label = Cups.Max();
            }
            return label;
        }
    }
}