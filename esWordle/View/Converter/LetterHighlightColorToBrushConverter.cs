using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace esWordle.View.Converter
{
    public class LetterHighlightColorToBrushConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is HighlightColor color)
            {
                switch (color)
                {
                    case HighlightColor.Gray:
                        // even though this is white and not gray, the TextBox will look gray because its disabled
                        return new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    case HighlightColor.Yellow:
                        return new SolidColorBrush(Color.FromRgb(255, 255, 0));
                    case HighlightColor.Green:
                        return new SolidColorBrush(Color.FromRgb(0, 204, 0));
                    default:
                        return new SolidColorBrush(Color.FromRgb(255, 255, 255)); // standard background
                }
            }
            return new SolidColorBrush(Color.FromRgb(255, 255, 255)); // standard background
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
