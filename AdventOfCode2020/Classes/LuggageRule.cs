using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class LuggageRuleSet
    {
        public IEnumerable<LuggageRule> Rules { get; }

        public LuggageRule this[string color] => Rules.First(x => x.Color == color);

        public LuggageRuleSet(IEnumerable<LuggageRule> rules)
        {
            Rules = rules;
        }

        private readonly Dictionary<(string, string), bool> memo = new();
        public bool CanEventuallyContain(string outer, string inner)
        {
            if (memo.TryGetValue((outer, inner), out bool value))
                return value;

            var rule = this[outer];
            value = rule.Contents.ContainsKey(inner) ||
                rule.Contents.Any(x => CanEventuallyContain(x.Key, inner));
            memo.Add((outer, inner), value);
            return value;
        }

        public int CountBags(string color)
        {
            return this[color].Contents.Sum(x => x.Value * (1 + CountBags(x.Key)));
        }
    }

    public class LuggageRule
    {
        public string Color { get; }
        public ReadOnlyDictionary<string, int> Contents { get; }

        public LuggageRule(string text)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            var regex = new Regex(@"^(?<color>.*?) bags contain ");
            var match = regex.Match(text);
            if (!match.Success)
                throw new FormatException("Invalid rule.");

            Color = match.Groups["color"].Value;

            var contents = new Dictionary<string, int>();
            var contentsStrings = text[(match.Index + match.Length)..].TrimEnd('.').Split(", ");
            foreach (var contentString in contentsStrings)
            {
                if (contentString != "no other bags")
                {
                    var contentRegex = new Regex(@"^(?<count>[0-9]+) (?<color>.*?) bags?\.?$");
                    var contentMatch = contentRegex.Match(contentString);
                    if (!contentMatch.Success)
                        throw new FormatException($"Invalid rule at {contentString}.");
                    var count = int.Parse(contentMatch.Groups["count"].Value);
                    var contentColor = contentMatch.Groups["color"].Value;
                    if (!contents.TryAdd(contentColor, count))
                        throw new FormatException($"Invalid rule. Duplicate color {contentColor}.");
                }
            }

            Contents = new(contents);
        }
    }
}