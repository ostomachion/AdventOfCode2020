using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class BusNotes
    {
        public int Timestamp { get; }
        public IEnumerable<int> BusIds { get; }

        public BusNotes(int timestamp, IEnumerable<int> busIds)
        {
            Timestamp = timestamp;
            BusIds = busIds;
        }

        public static BusNotes Parse(string text)
        {
            var lines = text.Split("\n");
            var timestamp = int.Parse(lines[0]);
            var busIds = lines[1].Split(',').Select(x => x == "x" ? 0 : int.Parse(x));
            return new BusNotes(timestamp, busIds);
        }

        public int GetNextBus() => BusIds.Where(x => x != 0).OrderBy(GetWaitTime).First();

        public int GetWaitTime(int id) => id - Timestamp % id;
    }
}