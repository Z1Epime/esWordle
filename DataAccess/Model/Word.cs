using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Word
    {
        public const int WordLength = 5;

        /// <summary>
        /// The letters of a word in their correct order.
        /// </summary>
        public IEnumerable<Letter> Letters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Word"/> class.
        /// Meant to be for JSON deserialization only
        /// </summary>
        public Word()
        {
            Letters = new List<Letter>();
        }

        public Word(string letters)
        {
            Letters = letters.Select(l => new Letter()
            {
                Character = l.ToString(),
            });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Word"/> class.
        /// </summary>
        /// <param name="letters">The letters of the word in their correct order.</param>
        public Word(IEnumerable<Letter> letters)
        {
            Letters = letters;
        }

        public string GetLettersAsString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Letter letter in Letters)
            {
                stringBuilder.Append(letter.Character);
            }

            return stringBuilder.ToString();
        }
    }
}
