using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace esWordle.View.Converter
{
    /// <summary>
    /// Converts multiple letters (<see cref="string"/>s) and the current <see cref="InputTry"/> to <see cref="Input"/> <br></br>
    /// </summary>
    public class InputConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.OfType<InputTry>().Count() != 1)
            {
                return Binding.DoNothing;
            }
            var inputTry = values.OfType<InputTry>().First();

            var colors = values.OfType<HighlightColor>().ToArray();
            if (colors.Length != Word.WordLength)
            {
                return Binding.DoNothing;
            }

            var lettersAsString = values.OfType<string>();
            if (lettersAsString.Count() != Word.WordLength)
            {
                return Binding.DoNothing;
            }

            var letters = lettersAsString.Select(letter => new Letter()
            {
                Character = letter,
            }).ToArray();

            // ._.
            letters[0].HighlightColor = colors[0];
            letters[1].HighlightColor = colors[1];
            letters[2].HighlightColor = colors[2];
            letters[3].HighlightColor = colors[3];
            letters[4].HighlightColor = colors[4];

            var word = new Word(letters);

            return new Input()
            {
                Word = word,
                Try = inputTry,
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value is Input input)
            {
                List<object> values = new List<object>();

                foreach (var letter in input.Word.Letters)
                {
                    values.Add(letter.Character);
                }

                values.Add(input.Try);

                return values.ToArray();
            }

            Debugger.Break();
            return Binding.DoNothing as object[];
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
