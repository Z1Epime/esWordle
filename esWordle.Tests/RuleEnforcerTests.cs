using DataAccess.Model;
using esWordle.ViewModel.Utils;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

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

        #region GetLetterHighlightColor_LetterDoesNotExist_ReturnsLetterHighlightColorGray
        
        [Test]
        [TestCaseSource(nameof(GetLetterHighlightColor_LetterDoesNotExist_ReturnsLetterHighlightColorGrayTestCases))]
        public void GetLetterHighlightColor_LetterDoesNotExist_ReturnsLetterHighlightColorGray(string letter, int index, Word word)
        {
            var result = ruleEnforcer.GetLetterHighlightColor(letter, index, word);

            Assert.That(result == LetterHighlightColor.Gray);
        }

        private static IEnumerable<TestCaseData> GetLetterHighlightColor_LetterDoesNotExist_ReturnsLetterHighlightColorGrayTestCases
        {
            get
            {
                var word = new Word("Knast");

                // Get alphabet without any letters of the word
                var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Where(a => !word.Letters.ToUpperInvariant().Contains(a)); 

                foreach (var letter in alphabet)
                {
                    for (int i = 0; i < 5; i++)
                        yield return new TestCaseData(letter.ToString(), i, word);
                }
            }
        }

        #endregion

        [Test]
        [TestCaseSource(nameof(GetLetterHighlightColor_InvalidInput_ThrowsArgumentExceptionTestCases))]
        public void GetLetterHighlightColor_InvalidInput_ThrowsArgumentException(string letter, int index, Word word)
        {
            Assert.Throws<ArgumentException>(() => ruleEnforcer.GetLetterHighlightColor(letter, index, word));
        }

        private static IEnumerable<TestCaseData> GetLetterHighlightColor_InvalidInput_ThrowsArgumentExceptionTestCases
        {
            get
            {
                yield return new TestCaseData("R", 0, new Word("Rizz"));
                yield return new TestCaseData("I", 1, new Word("Rizz"));
                yield return new TestCaseData("Z", 2, new Word("Rizz"));
                yield return new TestCaseData("Z", 3, new Word("Rizz"));

                yield return new TestCaseData("A", 0, new Word("aowijfdoiwajfdoiwa"));
                yield return new TestCaseData("A", 0, new Word("!?!?!?!?!"));
                yield return new TestCaseData("A", 0, new Word("f"));
                yield return new TestCaseData("A", 0, new Word("1"));
                yield return new TestCaseData("A", 0, new Word("2"));
                yield return new TestCaseData("A", 0, new Word("3"));
                yield return new TestCaseData("A", 0, new Word("123"));
                yield return new TestCaseData("A", 0, new Word("1234"));
                yield return new TestCaseData("A", 0, new Word("12345"));
                yield return new TestCaseData("A", 0, new Word("Wor!d"));
                yield return new TestCaseData("A", 0, new Word("R1zzy"));
                yield return new TestCaseData("A", 0, new Word("#1234"));
                yield return new TestCaseData("A", 0, new Word("gjtk."));
                yield return new TestCaseData("A", 0, new Word("G3T B!L43T3D"));
                yield return new TestCaseData("A", 0, new Word(",;.:-"));
                yield return new TestCaseData("A", 0, new Word("#'+*~"));
                yield return new TestCaseData("A", 0, new Word("!\"§$%"));
                yield return new TestCaseData("A", 0, new Word("&/()="));
                yield return new TestCaseData("A", 0, new Word("?`´^°"));
                yield return new TestCaseData("A", 0, new Word("<>|@€"));
                yield return new TestCaseData("A", 0, new Word("µµµµµ"));
                yield return new TestCaseData("A", 0, new Word("abcdü"));
                yield return new TestCaseData("A", 0, new Word("abcdä"));
                yield return new TestCaseData("A", 0, new Word("abcdö"));
                yield return new TestCaseData("A", 0, new Word("üäöäü"));
                yield return new TestCaseData("A", 0, new Word(""));
                yield return new TestCaseData("A", 0, new Word(String.Empty));
                yield return new TestCaseData("A", 0, new Word(int.MaxValue.ToString()));
                yield return new TestCaseData("A", 0, new Word(Double.NaN.ToString()));
                yield return new TestCaseData("A", 0, new Word(Binding.DoNothing.ToString()));
                yield return new TestCaseData("A", 0, new Word(DependencyProperty.UnsetValue.ToString()));
                yield return new TestCaseData("A", 0, new Word(String.Empty));
                yield return new TestCaseData("A", 0, new Word(null));
                yield return new TestCaseData("A", 0, new Word("\n\f\t"));
            }
        }
    }
}
