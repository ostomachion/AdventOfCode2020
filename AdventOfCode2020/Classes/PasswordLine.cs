using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class PasswordLine
    {
        private static readonly Regex regex = new Regex(@"(?<min>\d+)-(?<max>\d+) (?<c>[a-z]): (?<pw>[a-z]+)");

        public PasswordPolicy Policy { get; }
        public string Password { get; }

        public PasswordLine(PasswordPolicy policy, string password)
        {
            Policy = policy;
            Password = password;
        }

        public static PasswordLine Parse(string line)
        {
            var match = regex.Match(line);
            if (match is null)
                throw new ArgumentException(nameof(line));

            var min = Int32.Parse(match.Groups["min"].Value);
            var max = Int32.Parse(match.Groups["max"].Value);
            var c = match.Groups["c"].Value.Single();
            var password = match.Groups["pw"].Value;

            return new PasswordLine(new PasswordPolicy(c, min, max), password);
        }
    }
}