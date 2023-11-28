using DataAccess.Model;
using esWordle.ViewModel.Utils;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace esWordle.Tests
{
    [TestFixture]
    public class RuleEnforcerTests
    {
        private RuleEnforcer ruleEnforcer;

        [SetUp]
        public void SetUp()
        {
           ruleEnforcer = new RuleEnforcer();
        }

        #region GetLetterHighlightColor_LetterExistsButInWrongPosition_ReturnsLetterHighlightColorYellow
        [Test]
        [TestCaseSource(nameof(GetLetterHighlightColor_LetterExistsButInWrongPosition_ReturnsLetterHighlightColorYellowTestCases))]
        public void GetLetterHighlightColor_LetterExistsButInWrongPosition_ReturnsLetterHighlightColorYellow(string letter, int index, Word word)
        {
            var result = ruleEnforcer.GetLetterHighlightColor(letter, index, word);

            Assert.That(result == LetterHighlightColor.Yellow);
        }

        private static IEnumerable<TestCaseData> GetLetterHighlightColor_LetterExistsButInWrongPosition_ReturnsLetterHighlightColorYellowTestCases
        {
            get
            {
                #region Word "Mothy"
                yield return new TestCaseData("M", 1, new Word("Mothy"));
                yield return new TestCaseData("M", 2, new Word("Mothy"));
                yield return new TestCaseData("M", 3, new Word("Mothy"));
                yield return new TestCaseData("M", 4, new Word("Mothy"));

                yield return new TestCaseData("O", 0, new Word("Mothy"));
                yield return new TestCaseData("O", 2, new Word("Mothy"));
                yield return new TestCaseData("O", 3, new Word("Mothy"));
                yield return new TestCaseData("O", 4, new Word("Mothy"));

                yield return new TestCaseData("T", 0, new Word("Mothy"));
                yield return new TestCaseData("T", 1, new Word("Mothy"));
                yield return new TestCaseData("T", 3, new Word("Mothy"));
                yield return new TestCaseData("T", 4, new Word("Mothy"));

                yield return new TestCaseData("H", 0, new Word("Mothy"));
                yield return new TestCaseData("H", 1, new Word("Mothy"));
                yield return new TestCaseData("H", 2, new Word("Mothy"));
                yield return new TestCaseData("H", 4, new Word("Mothy"));
                
                yield return new TestCaseData("Y", 0, new Word("Mothy"));
                yield return new TestCaseData("Y", 1, new Word("Mothy"));
                yield return new TestCaseData("Y", 2, new Word("Mothy"));
                yield return new TestCaseData("Y", 3, new Word("Mothy"));
                #endregion

                #region Word "House"
                yield return new TestCaseData("H", 1, new Word("House"));
                yield return new TestCaseData("H", 2, new Word("House"));
                yield return new TestCaseData("H", 3, new Word("House"));
                yield return new TestCaseData("H", 4, new Word("House"));

                yield return new TestCaseData("O", 0, new Word("House"));
                yield return new TestCaseData("O", 2, new Word("House"));
                yield return new TestCaseData("O", 3, new Word("House"));
                yield return new TestCaseData("O", 4, new Word("House"));

                yield return new TestCaseData("U", 0, new Word("House"));
                yield return new TestCaseData("U", 1, new Word("House"));
                yield return new TestCaseData("U", 3, new Word("House"));
                yield return new TestCaseData("U", 4, new Word("House"));

                yield return new TestCaseData("S", 0, new Word("House"));
                yield return new TestCaseData("S", 1, new Word("House"));
                yield return new TestCaseData("S", 2, new Word("House"));
                yield return new TestCaseData("S", 4, new Word("House"));

                yield return new TestCaseData("E", 0, new Word("House"));
                yield return new TestCaseData("E", 1, new Word("House"));
                yield return new TestCaseData("E", 2, new Word("House"));
                yield return new TestCaseData("E", 3, new Word("House"));
                #endregion
            }
        }
        #endregion

        #region GetLetterHighlightColor_LetterExistsAndInCorrectPosition_ReturnsLetterHighlightColorGreen

        [Test]
        [TestCaseSource(nameof(GetLetterHighlightColor_LetterExistsAndInCorrectPosition_ReturnsLetterHighlightColorGreenTestCases))]
        public void GetLetterHighlightColor_LetterExistsAndInCorrectPosition_ReturnsLetterHighlightColorGreen(string letter, int index, Word word)
        {
            var result = ruleEnforcer.GetLetterHighlightColor(letter, index, word);

            Assert.That(result == LetterHighlightColor.Green);
        }

        private static IEnumerable<TestCaseData> GetLetterHighlightColor_LetterExistsAndInCorrectPosition_ReturnsLetterHighlightColorGreenTestCases
        {
            get
            {
                yield return new TestCaseData("M", 0, new Word("Mothy"));
                yield return new TestCaseData("O", 1, new Word("Mothy"));
                yield return new TestCaseData("T", 2, new Word("Mothy"));
                yield return new TestCaseData("H", 3, new Word("Mothy"));
                yield return new TestCaseData("Y", 4, new Word("Mothy"));

                yield return new TestCaseData("H", 0, new Word("House"));
                yield return new TestCaseData("O", 1, new Word("House"));
                yield return new TestCaseData("U", 2, new Word("House"));
                yield return new TestCaseData("S", 3, new Word("House"));
                yield return new TestCaseData("E", 4, new Word("House"));

                yield return new TestCaseData("P", 0, new Word("Panne"));
                yield return new TestCaseData("A", 1, new Word("Panne"));
                yield return new TestCaseData("N", 2, new Word("Panne"));
                yield return new TestCaseData("N", 3, new Word("Panne"));
                yield return new TestCaseData("E", 4, new Word("Panne"));
            }
        }
        #endregion
    }
}
