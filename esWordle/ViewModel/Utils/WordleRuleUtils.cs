using DataAccess;
using DataAccess.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace esWordle.ViewModel.Utils
{
    public class RuleEnforcer
    {
        public const string OnlyLettersRegex = "^[a-zA-Z]+$";

        public HighlightColor GetLetterHighlightColor(string letter, int index, Word word)
        {
            if (word == null)
            {
                throw new ArgumentException($"{nameof(word)} is null.");
            }

            if (string.IsNullOrWhiteSpace(word.GetLettersAsString()))
            {
                throw new ArgumentException($"{nameof(word)} has no letters.");
            }

            if (!Regex.IsMatch(word.GetLettersAsString(), OnlyLettersRegex))
            {
                throw new ArgumentException($"{nameof(word)} doesn't contain letters only.");
            }

            if (word.GetLettersAsString().Length != Word.WordLength)
            {
                throw new ArgumentException($"{nameof(word)} has wrong amount of characters.");
            }

            if (letter.Length != 1)
            {
                throw new ArgumentException($"{nameof(letter)} must have a single character.");
            }

            var result = HighlightColor.Gray;

            if (word.GetLettersAsString().Any(l => string.Equals(l.ToString(), letter, StringComparison.OrdinalIgnoreCase)))
            {
                result = HighlightColor.Yellow;

                if (word.Letters.ElementAt(index).Character.Equals(letter, StringComparison.OrdinalIgnoreCase))
                {
                    result = HighlightColor.Green;
                }
            }

            return result;
        }
    }
}
