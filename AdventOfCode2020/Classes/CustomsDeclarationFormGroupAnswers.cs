using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    /// <summary>
    /// Represents a group's answers to custom declaration forms.
    /// </summary>
    public class CustomsDeclarationFormGroupAnswers
    {
        /// <summary>
        /// A list of each <see cref="CustomDeclarationFormAnswers"/> for each
        /// member of the group.
        /// </summary>
        public IEnumerable<CustomsDeclarationFormAnswers> Answers { get; }

        /// <summary>
        /// Creates an instance of
        /// <see cref="CustomsDeclarationFormGroupAnswers"/> from a string.
        /// </summary>
        /// <param name="text">
        /// The string to parse. Each line of the string should be a valid
        /// <see cref="CustomDeclarationsFormAnswers"/> string.
        /// </param>
        public CustomsDeclarationFormGroupAnswers(string text)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            Answers = text.Split("\n").Select(x => new CustomsDeclarationFormAnswers(x));
        }
    }
}