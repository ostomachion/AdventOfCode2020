using System.Xml.Linq;
using System.Collections;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class MemoryGame
    {
        private int turn = 0;
        private Dictionary<int, int> olderSpoken = new();
        private int lastSpoken;
        public IEnumerable<int> StartingNumbers { get; }

        public MemoryGame(IEnumerable<int> startingNumbers)
        {
            StartingNumbers = startingNumbers;
        }

        private int Speak(int i)
        {
            if (turn != 0)
            {
                if (olderSpoken.ContainsKey(lastSpoken))
                    olderSpoken[lastSpoken] = turn - 1;
                else
                    olderSpoken.Add(lastSpoken, turn - 1);
            }

            lastSpoken = i;
            turn++;

            return i;
        }

        public int Next()
        {
            if (turn < StartingNumbers.Count())
                return Speak(StartingNumbers.ElementAt(turn));

            if (olderSpoken.ContainsKey(lastSpoken))
            {
                return Speak(turn - 1 - olderSpoken[lastSpoken]);
            }
            else
            {
                return Speak(0);
            }
        }

        public IEnumerable<int> Play()
        {
            while (true)
            {
                yield return Next();
            }
        }
    }
}