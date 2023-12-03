using DataAccess.Model;
using DataAccess.Resources;
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
    /// Grants access to a list of <see cref="Word"/>s recieved from <see cref="DefaultData.Words"/> <br></br>
    /// <see cref="DefaultData.Words"/> gets deserialized as JSON the first time accessing <see cref="Words"/>
    /// </summary>
    public class WordAccessor
    {
        public Lazy<Task<List<Word>>> Words { get; set; }

        public WordAccessor()
        {
            Words = new Lazy<Task<List<Word>>>(GetWords);
        }

        private async Task<List<Word>> GetWords()
        {
            byte[] stream = DefaultData.Words;

            string json;
            using (StreamReader r = new StreamReader(new MemoryStream(stream)))
            {
                json = await r.ReadToEndAsync();
            }

            List<Word> words = JsonConvert.DeserializeObject<List<Word>>(json);
            return words;
        }
    }
}
