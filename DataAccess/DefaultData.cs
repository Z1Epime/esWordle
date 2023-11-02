using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DefaultData
    {
        public static readonly List<Word> DEFAULT_WORDS =
            new List<Word>
            {
                new Word("Motherfucker"),
                new Word("Fatherfucker"),
                new Word("SomeSeriousFuckingWord"),
                new Word("WhyAmIWritingPascalCase"),
                new Word("NooneProbablyGuessesThis"),
            };
    }
}
