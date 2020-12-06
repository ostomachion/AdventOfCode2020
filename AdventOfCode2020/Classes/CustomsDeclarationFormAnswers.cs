using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class CustomsDeclarationFormGroupAnswers
    {
        public IEnumerable<CustomsDeclarationFormAnswers> Answers { get; }

        public CustomsDeclarationFormGroupAnswers(string text)
        {
            Answers = text.Split("\n").Select(x => new CustomsDeclarationFormAnswers(x));
        }
    }

    public class CustomsDeclarationFormAnswers
    {
        public static readonly IEnumerable<char> Questions = "abcdefghijklmnopqrstuvwxyz";

        private readonly HashSet<char> yesAnswers = new HashSet<char>();

        public CustomsDeclarationFormAnswers(string text)
        {
            yesAnswers = text.ToCharArray().ToHashSet();
        }

        public bool Answer(char c) => yesAnswers.Contains(c);
    }
}