using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020
{
    public static class Day13
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/13
        /// </summary>
        public static void Part1()
        {
            var notes = BusNotes.Parse(Input.Get(13));
            var earliest = notes.GetNextBus();
            var waitTime = notes.GetWaitTime(earliest);
            Console.WriteLine(earliest * waitTime);
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/13#part2
        /// </summary>
        public static void Part2()
        {
            var notes = BusNotes.Parse(Input.Get(13));
            var t = Contest(notes.BusIds.ToArray());

            Console.WriteLine(t);
        }

        // This is very ugly code.
        public static BigInteger Contest(int[] buses)
        {
            // Find the minimum t such that
            // t + i is divisible by buses[i]
            // for all buses[i] != 0
            BigInteger t = buses.First();
            BigInteger dt = buses.First();
            var found = 1;
            while (found != buses.Length)
            {
                while (true)
                {
                    if (buses[found] == 0 || ((t + found) % buses[found]) == 0)
                    {
                        dt *= buses[found] == 0 ? 1 : buses[found];
                        found++;
                        if (found == buses.Length)
                            return t;
                    }
                    else
                    {
                        break;
                    }
                }
                t += dt;
            }
            throw new Exception("Wat.");
        }
    }
}