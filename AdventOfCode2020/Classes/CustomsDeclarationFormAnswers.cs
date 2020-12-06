using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    /// <summary>
    /// Represents an individual's answers to a customs declaration form.
    /// </summary>
    public class CustomsDeclarationFormAnswers
    {
        /// <summary>
        /// A list of questions on the customs declaration form.
        /// </summary>
        public static readonly IEnumerable<char> Questions = "abcdefghijklmnopqrstuvwxyz";

        private readonly HashSet<char> yesAnswers = new HashSet<char>();

        /// <summary>
        /// Creates an instance of <see cref="CustomsDeclarationFormAnswers"/>
        /// from a string.
        /// </summary>
        /// <param name="text">
        /// The string to parse. Each character represents a question that the
        /// individual answered yes to.
        /// </param>
        public CustomsDeclarationFormAnswers(string text)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            yesAnswers = text.ToCharArray().ToHashSet();

            if (yesAnswers.Except(Questions).Any())
                throw new FormatException("Invalid format.");
        }

        /// <summary>
        /// Determines whether the individual answered yes to the given
        /// question.
        /// </summary>
        /// <param name="question">The question to check.</param>
        /// <returns>
        /// <c>true</c> if the individual answered yes to the given question;
        /// otherwise, <c>false</c>.
        /// </returns>
        public bool Answer(char question) => yesAnswers.Contains(question);
    }
}
