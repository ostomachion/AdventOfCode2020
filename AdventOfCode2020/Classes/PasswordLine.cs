using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    /// <summary>
    /// Represents a line from a password log, containing both the password
    /// policy and the password.
    /// </summary>
    public class PasswordLine
    {
        private static readonly Regex regex = new Regex(@"(?<min>\d+)-(?<max>\d+) (?<c>[a-z]): (?<pw>[a-z]+)");

        /// <summary>
        /// The password policy used to set the password.
        /// </summary>
        public PasswordPolicy Policy { get; }

        /// <summary>
        /// The password. It may not satisfy the policy.
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Creates an instance of <see cref="PasswordLine"/>.
        /// </summary>
        /// <param name="policy">The <see cref="PasswordLine"/>.</param>
        /// <param name="password">The password.</param>
        public PasswordLine(PasswordPolicy policy, string password)
        {
            Policy = policy ?? throw new ArgumentNullException(nameof(policy));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        /// <summary>
        /// Creates an instance of <see cref="PasswordLine"/> from a line in a password file.
        /// </summary>
        /// <param name="line">The line from a password file.</param>
        /// <returns>The parsed <see cref="PasswordLine"/></returns>
        public static PasswordLine Parse(string line)
        {
            if (line is null)
                throw new ArgumentNullException(nameof(line));

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