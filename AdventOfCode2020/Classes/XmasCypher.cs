using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class XmasCypher
    {
        public int PreambleSize { get; init; } = 25;

        private int[] value;

        public XmasCypher(IEnumerable<int> value)
        {
            this.value = value.ToArray();
        }

        private bool IsValidPosition(int index)
        {
            if (index <= PreambleSize)
                return true;

            var prev = value[(index - PreambleSize)..index];

            for (var i = 0; i < PreambleSize; i++)
            {
                for (int j = 0; j < PreambleSize; j++)
                {
                    if (i == j)
                        continue;
                    if (prev[i] + prev[j] == value[index])
                        return true;
                }
            }

            return false;
        }

        public int FindNonSumNumber()
        {
            return value[Enumerable.Range(0, value.Length).First(x => !IsValidPosition(x))];
        }
    }
}