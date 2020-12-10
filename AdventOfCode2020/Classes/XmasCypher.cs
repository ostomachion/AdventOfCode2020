using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public class XmasCypher
    {
        public int PreambleSize { get; init; } = 25;

        private readonly BigInteger[] value;

        public XmasCypher(IEnumerable<BigInteger> value)
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

        public BigInteger FindNonSumNumber()
        {
            return value[Enumerable.Range(0, value.Length).First(x => !IsValidPosition(x))];
        }

        public Span<BigInteger> FindKey(BigInteger sum)
        {
            for (var i = 0; i < value.Length; i++)
            {
                var test = value[i];
                for (var j = i + 1; j < value.Length; j++)
                {
                    test += value[j];
                    if (test == sum)
                    {
                        return value.AsSpan()[i..(j + 1)];
                    }
                    else if (test > sum)
                    {
                        break;
                    }
                }
            }
            throw new Exception("No key found.");
        }
    }
}