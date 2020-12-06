using System;
using Xunit;
using AdventOfCode2020;
using System.Linq;

namespace AdventOfCode2020Tests
{
    public class Day06Tests
    {
        [Fact]
        public void Part1SingleGroupTest()
        {
            // Given
            var answers = new CustomsDeclarationFormGroupAnswers(Input.Get(6, "SingleGroup"));

            // When
            var anyoneYes = CustomsDeclarationFormAnswers.Questions.Count(x => answers.Answers.Any(y => y.Answer(x)));

            // Then
            Assert.Equal(6, anyoneYes);
        }

        [Fact]
        public void Part1Test()
        {
            // Given
            var answers = Input.GetGroups(6).Select(x => new CustomsDeclarationFormGroupAnswers(x));

            // When
            var anyoneYes = answers.Select(a => CustomsDeclarationFormAnswers.Questions
                .Count(x => a.Answers.Any(y => y.Answer(x))));

            // Then
            Assert.Equal(new[] { 3, 3, 3, 1, 1 }, anyoneYes);
        }
    }
}
