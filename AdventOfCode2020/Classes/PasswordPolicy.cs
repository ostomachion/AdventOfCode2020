using System;
using System.Linq;

namespace AdventOfCode2020
{
    /// <summary>
    /// Represents a password policy requiring either a
    /// certain number of a specific character, or a
    /// character in a specific location.
    /// </summary>
    /// <remarks>Used with <see cref="Day02"/>.</remarks>
    public class PasswordPolicy
    {
        /// <summary>
        /// The character required for the password.
        /// </summary>
        public char RequiredCharacter { get; }

        /// <summary>
        /// Either the minimum number of times the character may
        /// appear in the password, or one of the indexes that
        /// the character may appear in, depending on the policy.
        /// </summary>
        public int Min { get; }

        /// <summary>
        /// Either the maximum number of times the character may
        /// appear in the password, or one of the indexes that
        /// the character may appear in, depending on the policy.
        /// </summary>
        public int Max { get; }

        /// <summary>
        /// Creates an instance of <see cref="PasswordPolicy"/>.
        /// </summary>
        /// <param name="requiredCharacter">The required character.</param>
        /// <param name="min">The minimum number.</param>
        /// <param name="max">The maximum number.</param>
        public PasswordPolicy(char requiredCharacter, int min, int max)
        {
            RequiredCharacter = requiredCharacter;
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Checks that the given password contains the required character
        /// at least <see cref="Min"/> times and at most <see cref="Max"/>
        /// times (inclusive).
        /// </summary>
        /// <param name="password">The password to check</param>
        /// <returns>
        /// Whether the given password contains the required character
        /// at least <see cref="Min"/> times and at most <see cref="Max"/>
        /// times (inclusive).
        /// </returns>
        public bool OldSystemCheck(string password)
        {
            if (password is null)
                throw new ArgumentNullException(nameof(password));

            var count = password.Count(c => c == RequiredCharacter);
            return count >= Min && count <= Max;
        }

        /// <summary>
        /// Checks that the given password contains the required character
        /// at either index <see cref="Min"/> or index <see cref="Max"/>
        /// (where 1 is the first position), but not both.
        /// </summary>
        /// <param name="password">The password to check</param>
        /// <returns>
        /// Whether the given password contains the required character
        /// at either index <see cref="Min"/> or index <see cref="Max"/>
        /// (where 1 is the first position), but not both.
        /// </returns>
        public bool NewSystemCheck(string password)
        {
            if (password is null)
                throw new ArgumentNullException(nameof(password));

            return (password[Min - 1] == RequiredCharacter) ^ (password[Max - 1] == RequiredCharacter);
        }
    }
}