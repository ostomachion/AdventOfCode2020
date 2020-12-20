using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class MessageRuleSet
    {
        private readonly Dictionary<int, MessageRule> value;

        public MessageRule this[int i]
        {
            get => value[i];
            set
            {
                value.SetRuleSet(this);
                this.value[i] = value;
            }
        }

        public MessageRuleSet(Dictionary<int, MessageRule> value)
        {
            foreach (var v in value.Values)
                v.SetRuleSet(this);
            this.value = value;
        }

        public static MessageRuleSet Parse(string text)
        {
            return new MessageRuleSet(text.Split('\n')
                .Select(x => x.Split(": ", 2))
                .ToDictionary(x => int.Parse(x[0]), x => MessageRule.Parse(x[1])));
        }
    }

    public abstract class MessageRule
    {
        public MessageRuleSet? RuleSet { get; set; }
        public abstract IEnumerable<int> Match(string input, int index);

        public bool Matches(string input) => Match(input, 0).Contains(input.Length);

        public static MessageRule Parse(string text)
        {
            if (text.StartsWith("\""))
                return new CharMessageRule(text[1]);

            return new AltMessageRule(text.Split(" | ")
                .Select(x => new ConcatMessageRule(x.Split(' ')
                    .Select(y => new RefMessageRule(int.Parse(y))).ToList())).ToList());
        }

        public abstract void SetRuleSet(MessageRuleSet ruleSet);
    }

    public class CharMessageRule : MessageRule
    {
        public char Char { get; }

        public CharMessageRule(char c)
        {
            Char = c;
        }

        public override IEnumerable<int> Match(string input, int index)
        {
            if (index >= 0 && index < input.Length && input[index] == Char)
                yield return 1;
        }

        public override void SetRuleSet(MessageRuleSet ruleSet)
        {
            RuleSet = ruleSet;
        }
    }

    public class ConcatMessageRule : MessageRule
    {
        public IEnumerable<MessageRule> Rules { get; }

        public ConcatMessageRule(IEnumerable<MessageRule> rules)
        {
            Rules = rules;
        }

        public override IEnumerable<int> Match(string input, int index)
        {
            if (!Rules.Any())
            {
                yield return 0;
                yield break;
            }

            var head = Rules.First();
            var tail = new ConcatMessageRule(Rules.Skip(1)) { RuleSet = RuleSet };
            foreach (var headMatch in head.Match(input, index))
            {
                foreach (var tailMatch in tail.Match(input, index + headMatch))
                {
                    yield return headMatch + tailMatch;
                }
            }
        }

        public override void SetRuleSet(MessageRuleSet ruleSet)
        {
            RuleSet = ruleSet;
            foreach (var rule in Rules)
                rule.SetRuleSet(ruleSet);
        }
    }

    public class AltMessageRule : MessageRule
    {
        public IEnumerable<MessageRule> Rules { get; }

        public AltMessageRule(IEnumerable<MessageRule> rules)
        {
            Rules = rules;
        }

        public override IEnumerable<int> Match(string input, int index)
        {
            return Rules.SelectMany(x => x.Match(input, index));
        }

        public override void SetRuleSet(MessageRuleSet ruleSet)
        {
            RuleSet = ruleSet;
            foreach (var rule in Rules)
                rule.SetRuleSet(ruleSet);
        }
    }

    public class RefMessageRule : MessageRule
    {
        public int Key { get; }

        public RefMessageRule(int key)
        {
            Key = key;
        }

        public override IEnumerable<int> Match(string input, int index)
        {
            if (RuleSet is null)
                throw new InvalidOperationException();
            return RuleSet[Key].Match(input, index);
        }

        public override void SetRuleSet(MessageRuleSet ruleSet)
        {
            RuleSet = ruleSet;
        }
    }
}