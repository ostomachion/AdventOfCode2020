using System.Xml.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class TicketNotes
    {
        public Dictionary<string, TicketRange> Fields = new();

        public IEnumerable<int> YourTicket { get; }

        public IEnumerable<IEnumerable<int>> NearbyTickets { get; }

        public TicketNotes(Dictionary<string, TicketRange> fields, IEnumerable<int> yourTicket, IEnumerable<IEnumerable<int>> nearbyTickets)
        {
            Fields = fields;
            YourTicket = yourTicket;
            NearbyTickets = nearbyTickets;
        }

        public static TicketNotes Parse(string text)
        {
            var groups = text.Split("\n\n", 3);
            return new TicketNotes(ParseFields(groups[0]), ParseYourTicket(groups[1]), ParseNearbyTickets(groups[2]));
        }

        private static Dictionary<string, TicketRange> ParseFields(string text)
        {
            Dictionary<string, TicketRange> value = new();
            foreach (var line in text.Split('\n'))
            {
                var parts = line.Split(": ", 2);
                value.Add(parts[0], TicketRange.Parse(parts[1]));
            }
            return value;
        }

        private static IEnumerable<int> ParseTicket(string text)
        {
            return text.Split(',').Select(int.Parse);
        }

        private static IEnumerable<int> ParseYourTicket(string text)
        {
            var lines = text.Split('\n', 2);
            if (lines[0] != "your ticket:")
                throw new FormatException();
            return ParseTicket(lines[1]);
        }

        private static IEnumerable<IEnumerable<int>> ParseNearbyTickets(string text)
        {
            var lines = text.Split('\n');
            if (lines[0] != "nearby tickets:")
                throw new FormatException();
            return lines[1..].Select(ParseTicket);
        }

        public bool IsPossibleValue(int i) => Fields.Values.Any(x => x.Contains(i));

        public IEnumerable<int> FindImpossibleValues() => NearbyTickets.SelectMany(x => x.Where(y => !IsPossibleValue(y)));

        public IEnumerable<string> GetFieldOrder()
        {
            var validTickets = NearbyTickets.Where(x => x.All(IsPossibleValue)).Append(YourTicket);

            List<List<string>> possibleValues = new();
            for (var i = 0; i < YourTicket.Count(); i++)
            {
                possibleValues.Add(Fields.Keys.Where(f =>
                    validTickets.Select(t => t.ElementAt(i)).All(Fields[f].Contains)).ToList());
            }

            while (possibleValues.Any(x => x.Count > 1))
            {
                for (var i = 0; i < possibleValues.Count; i++)
                {
                    if (possibleValues[i].Count == 1)
                    {
                        var field = possibleValues[i].Single();
                        for (var j = 0; j < possibleValues.Count; j++)
                        {
                            if (i != j)
                            {
                                possibleValues[j].Remove(field);
                            }
                        }
                    }
                }
            }

            return possibleValues.Select(x => x.Single());
        }
    }

    public struct TicketRange
    {
        public int Min1 { get; }
        public int Max1 { get; }
        public int Min2 { get; }
        public int Max2 { get; }

        private static readonly Regex regex = new(@"^(?<min1>\d+)-(?<max1>\d+) or (?<min2>\d+)-(?<max2>\d+)$");

        public TicketRange(int min1, int max1, int min2, int max2)
        {
            Min1 = min1;
            Max1 = max1;
            Min2 = min2;
            Max2 = max2;
        }

        public static TicketRange Parse(string text)
        {
            var match = regex.Match(text);
            if (!match.Success)
                throw new FormatException();

            return new TicketRange(
                int.Parse(match.Groups["min1"].Value),
                int.Parse(match.Groups["max1"].Value),
                int.Parse(match.Groups["min2"].Value),
                int.Parse(match.Groups["max2"].Value));
        }

        public bool Contains(int i) => i >= Min1 && i <= Max1 || i >= Min2 && i <= Max2;
    }
}