using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Word
    {
        /// <summary>
        /// The letters of a word in their correct order.
        /// </summary>
        public string Letters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Word"/> class.
        /// Meant to be for JSON deserialization only
        /// </summary>
        public Word()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Word"/> class.
        /// </summary>
        /// <param name="letters">The letters of the word in their correct order.</param>
        public Word(string letters)
        {
            Letters = letters;
        }
    }
}
