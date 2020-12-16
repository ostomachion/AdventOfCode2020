using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day16
    {
        /// <summary>
        /// https://adventofcode.com/2020/day/16
        /// </summary>
        public static void Part1()
        {
            var notes = TicketNotes.Parse(Input.Get(16));
            var values = notes.FindImpossibleValues();

            Console.WriteLine(values.Sum());
        }

        /// <summary>
        /// https://adventofcode.com/2020/day/16#part2
        /// </summary>
        public static void Part2()
        {
            var notes = TicketNotes.Parse(Input.Get(16));
            var order = notes.GetFieldOrder();

            var depatureIndexes = order.Select((x, i) => (Value: x, Index: i))
                .Where(x => x.Value.StartsWith("departure"))
                .Select(x => x.Index);

            var departureFields = depatureIndexes.Select(i => notes.YourTicket.ElementAt(i));
            var product = departureFields.Aggregate(BigInteger.One, (x, y) => x * y);

            Console.WriteLine(product);
        }
    }
}