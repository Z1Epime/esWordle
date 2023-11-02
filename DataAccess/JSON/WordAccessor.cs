using DataAccess.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataAccess.JSON
{
    /// <summary>
    /// Serialization and deserialization of the <see cref="Word"/>s in JSON.
    /// </summary>
    public class WordAccessor
    {
        private static readonly string APP_DATA_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string RELATIVE_SAVE_PATH = "\\esWordle\\";
        private static readonly string FILE = "words.json";
        private readonly string fullPath = APP_DATA_PATH + RELATIVE_SAVE_PATH + FILE;

        /// <summary>
        /// Returns the words specified in the hardcoded path in the ApplicationData folder. <br/>
        /// If the path and file cannot be found, they will be created with the <br/> 
        /// default word set specified in <see cref="DefaultData.DEFAULT_WORDS"/>.
        /// </summary>
        public async Task<List<Word>> GetWords()
        {
            if (!File.Exists(fullPath))
            {
                await SetWords(DefaultData.DEFAULT_WORDS);
            }

            string json;
            using (StreamReader r = new StreamReader(fullPath))
            {
                json = await r.ReadToEndAsync();
            }

            List<Word> words = JsonConvert.DeserializeObject<List<Word>>(json);
            return words;
        }

        /// <summary>
        /// Serializes the words specified in <paramref name="words"/> in the hardcoded path <br/>
        /// in the ApplicationData folder.
        /// </summary>
        /// <param name="words">The words to serialize in the hardcoded path.</param>
        public async Task SetWords(List<Word> words)
        {
            if (!File.Exists(fullPath))
            {
                Directory.CreateDirectory(APP_DATA_PATH + RELATIVE_SAVE_PATH);
                string json = JsonConvert.SerializeObject(words);
                await File.WriteAllTextAsync(fullPath, json);
            }
        }
    }
}
