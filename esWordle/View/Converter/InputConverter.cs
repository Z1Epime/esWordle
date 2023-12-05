using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
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

            var letters = values.OfType<string>().Where(s => !string.IsNullOrWhiteSpace(s));

            if (letters.Count() != Word.WordLength)
            {
                return Binding.DoNothing;
            }

            var inputTry = values.OfType<InputTry>().First();

            var word = string.Join("", letters);

            return new Input()
            {
                Word = new Word(word),
                Try = inputTry,
            };
        }

        /// <summary>
        /// Converting back not supported.
        /// </summary>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            Debugger.Break();
            return Binding.DoNothing as object[];
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
