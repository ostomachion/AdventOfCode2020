using System;

namespace AdventOfCode2020
{
    public class PasswordPolicy
    {
        public char RequiredCharacter { get; }
        public Range Range { get; }

        public PasswordPolicy(char requiredCharacter, Range range)
        {
            RequiredCharacter = requiredCharacter;
            Range = range;
        }

        public bool Check(string password)
        {
            throw new NotImplementedException();
        }
    }
}