using System;

namespace AdventOfCode2020
{
    public class PasswordLine
    {
        public PasswordPolicy Policy { get; }
        public string Password { get; }

        public PasswordLine(PasswordPolicy policy, string password)
        {
            Policy = policy;
            Password = password;
        }

        public static PasswordLine Parse(string line)
        {
            throw new NotImplementedException();
        }
    }
}