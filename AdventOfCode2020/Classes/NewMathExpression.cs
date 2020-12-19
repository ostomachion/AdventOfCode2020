using System.Numerics;
using System.Text.RegularExpressions;
using System;
namespace AdventOfCode2020
{
    public class NewMathExpression
    {
        public static BigInteger Evaluate(string text)
        {
            while (Regex.Match(text, @"\((?<inner>\d+( [+*] \d+)*)\)") is { Success: true } match)
            {
                var reduced = Evaluate(match.Groups["inner"].Value);
                text = text[0..match.Index] + reduced.ToString() + text[(match.Index + match.Length)..];
            }

            while (Regex.Match(text, @"^(?<left>\d+) ((?<plus>\+)|(?<times>\*)) (?<right>\d+)") is { Success: true } match)
            {
                var left = BigInteger.Parse(match.Groups["left"].Value);
                var right = BigInteger.Parse(match.Groups["right"].Value);
                var plus = match.Groups["plus"].Success;
                var reduced = plus ? left + right : left * right;
                text = reduced.ToString() + text[(match.Index + match.Length)..];
            }

            return BigInteger.Parse(text);
        }

        public static BigInteger EvaluateAdvanced(string text)
        {
            while (Regex.Match(text, @"\((?<inner>\d+( [+*] \d+)*)\)") is { Success: true } match)
            {
                var reduced = EvaluateAdvanced(match.Groups["inner"].Value);
                text = text[0..match.Index] + reduced.ToString() + text[(match.Index + match.Length)..];
            }

            while (Regex.Match(text, @"(?<left>\d+) \+ (?<right>\d+)") is { Success: true } match)
            {
                var left = BigInteger.Parse(match.Groups["left"].Value);
                var right = BigInteger.Parse(match.Groups["right"].Value);
                var reduced = left + right;
                text = text[0..match.Index] + reduced.ToString() + text[(match.Index + match.Length)..];
            }

            while (Regex.Match(text, @"(?<left>\d+) \* (?<right>\d+)") is { Success: true } match)
            {
                var left = BigInteger.Parse(match.Groups["left"].Value);
                var right = BigInteger.Parse(match.Groups["right"].Value);
                var reduced = left * right;
                text = text[0..match.Index] + reduced.ToString() + text[(match.Index + match.Length)..];
            }

            return BigInteger.Parse(text);
        }
    }
}