using System;
using System.Linq;

namespace AdventOfCode2020
{
    public class PasswordPolicy
    {
        public char RequiredCharacter { get; }
        public int Min { get; }
        public int Max { get; }

        public PasswordPolicy(char requiredCharacter, int min, int max)
        {
            RequiredCharacter = requiredCharacter;
            Min = min;
            Max = max;
        }

        public bool OldSystemCheck(string password)
        {
            var count = password.Count(c => c == RequiredCharacter);
            return count >= Min && count <= Max;
        }

        public bool NewSystemCheck(string password)
        {
            return (password[Min - 1] == RequiredCharacter) ^ (password[Max - 1] == RequiredCharacter);
        }
    }
}