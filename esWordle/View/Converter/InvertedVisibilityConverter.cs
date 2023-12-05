using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace esWordle.View.Converter
{
    /// <summary>
    /// Converts <see cref="Visibility.Visible"/> to <see cref="Visibility.Collapsed"/>, <br></br>
    /// <see cref="Visibility.Collapsed"/> to <see cref="Visibility.Visible"/> and <br></br>
    /// <see cref="Visibility.Hidden"/> to <see cref="Visibility.Visible"/>  
    /// </summary>
    public class InvertedVisibilityConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility && visibility == Visibility.Visible)
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility && visibility == Visibility.Visible)
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
