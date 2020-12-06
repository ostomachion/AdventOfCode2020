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
}