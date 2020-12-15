using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class MemoryGame
    {
        private List<int> spoken = new();
        public IEnumerable<int> StartingNumbers { get; }

        public MemoryGame(IEnumerable<int> startingNumbers)
        {
            StartingNumbers = startingNumbers;
        }

        public int Next()
        {
            throw new NotImplementedException();
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