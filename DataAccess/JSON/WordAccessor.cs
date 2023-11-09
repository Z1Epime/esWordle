using DataAccess.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DataAccess.JSON
{
    /// <summary>
    /// Deserialization of <see cref="Word"/>s in JSON.
    /// </summary>
    public class WordAccessor
    {
        /// <summary>
        /// Returns the words copied to the programm installation directory. <br/>
        /// </summary>
        public async Task<List<Word>> GetWords()
        {
            var uri = new Uri("/DefaultData.json", UriKind.Relative);
            var contentStream = Application.GetContentStream(uri);

            string json;
            using (StreamReader r = new StreamReader(contentStream.Stream))
            {
                json = await r.ReadToEndAsync();
            }

            List<Word> words = JsonConvert.DeserializeObject<List<Word>>(json);
            return words;
        }
    }
}
