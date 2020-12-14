using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public struct SeaPortMask
    {
        public ulong OneMask { get; private set; }
        public ulong ZeroMask { get; private set; }

        public SeaPortMask(string text)
        {
            ZeroMask = Convert.ToUInt64(text.Replace('X', '1'), 2);
            OneMask = Convert.ToUInt64(text.Replace('X', '0'), 2);
        }

        public SeaPortMask(ulong zeroMask, ulong oneMask)
        {
            ZeroMask = zeroMask;
            OneMask = oneMask;
        }

        public ulong Apply(ulong value)
        {
            return value & ZeroMask | OneMask;
        }

        public SeaPortMask ApplyV2(ulong value)
        {
            var valueMask = new SeaPortMask(value, value);
            for (var i = 0; i < 36; i++)
            {
                var bit = GetBit(i);
                if (bit != 0)
                {
                    valueMask.SetBit(i, bit);
                }
            }
            return valueMask;
        }

        public int GetBit(int index)
        {
            var zeroBit = (ZeroMask >> index) % 2;
            var oneBit = (OneMask >> index) % 2;
            return (zeroBit, oneBit) switch
            {
                (0, 0) => 0,
                (1, 1) => 1,
                (1, 0) => -1,
                _ => throw new InvalidOperationException()
            };
        }

        public override bool Equals(object? obj)
        {
            return obj is SeaPortMask mask &&
                   OneMask == mask.OneMask &&
                   ZeroMask == mask.ZeroMask;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OneMask, ZeroMask);
        }

        private static readonly Dictionary<SeaPortMask, IEnumerable<ulong>> memo = new();
        public IEnumerable<ulong> GetValues()
        {
            if (memo.TryGetValue(this, out var value))
                return value;
            value = Inner(this);
            memo.Add(this, value);
            return value;

            static IEnumerable<ulong> Inner(SeaPortMask mask)
            {
                for (var i = 0; i < 36; i++)
                {
                    if (mask.GetBit(i) == -1)
                    {
                        foreach (var value in mask.WithBit(i, 0).GetValues())
                            yield return value;
                        foreach (var value in mask.WithBit(i, 1).GetValues())
                            yield return value;
                        yield break;
                    }
                }

                yield return mask.ZeroMask | mask.OneMask;
            }
        }

        public SeaPortMask WithBit(int index, int value)
        {
            return value switch
            {
                0 => new SeaPortMask(SetBit(ZeroMask, index, false), SetBit(OneMask, index, false)),
                1 => new SeaPortMask(SetBit(ZeroMask, index, true), SetBit(OneMask, index, true)),
                -1 => new SeaPortMask(SetBit(ZeroMask, index, true), SetBit(OneMask, index, false)),
                _ => throw new InvalidOperationException()
            };

            static ulong SetBit(ulong l, int index, bool value)
            {
                return value ? l | 1ul << index : l & ~(1ul << index);
            }
        }

        public void SetBit(int index, int value)
        {
            (ZeroMask, OneMask) = value switch
            {
                0 => (SetBit(ZeroMask, index, false), SetBit(OneMask, index, false)),
                1 => (SetBit(ZeroMask, index, true), SetBit(OneMask, index, true)),
                -1 => (SetBit(ZeroMask, index, true), SetBit(OneMask, index, false)),
                _ => throw new InvalidOperationException()
            };

            static ulong SetBit(ulong l, int index, bool value)
            {
                return value ? l | 1ul << index : l & ~(1ul << index);
            }
        }

        public override string ToString()
        {
            var self = this;
            return new string(Enumerable.Range(0, 36).Select(i => GetChar(self.GetBit(i))).Reverse().ToArray());
        }

        private static char GetChar(int bit) => bit switch
        {
            0 => '0',
            1 => '1',
            -1 => 'X',
            _ => throw new InvalidOperationException()
        };

        public static bool operator ==(SeaPortMask left, SeaPortMask right) => left.Equals(right);
        public static bool operator !=(SeaPortMask left, SeaPortMask right) => !(left == right);
    }
}