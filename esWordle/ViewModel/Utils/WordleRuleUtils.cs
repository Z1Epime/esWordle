using DataAccess;
using DataAccess.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esWordle.ViewModel.Utils
{
    public enum LetterHighlightColor
    {
        Gray,
        Yellow,
        Green,
    }

    public class RuleEnforcer
    {
        public LetterHighlightColor GetLetterHighlightColor(string letter, int index, Word word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            if (string.IsNullOrWhiteSpace(word.Letters))
            {
                throw new ArgumentException($"{nameof(word)} has no letters.");
            }

            if (word.Letters.Length != Word.WordLength)
            {
                throw new ArgumentException($"{nameof(word)} has wrong amount of characters.");
            }

            if (letter.Length != 1)
            {
                throw new ArgumentException($"{nameof(letter)} must have a single character.");
            }

            var result = LetterHighlightColor.Gray;

            if (word.Letters.Any(l => string.Equals(l.ToString(), letter, StringComparison.OrdinalIgnoreCase)))
            {
                result = LetterHighlightColor.Yellow;

                if (word.Letters.ElementAt(index).ToString().Equals(letter, StringComparison.OrdinalIgnoreCase))
                {
                    result = LetterHighlightColor.Green;
                }
            }

            return result;
        }

    }
}
