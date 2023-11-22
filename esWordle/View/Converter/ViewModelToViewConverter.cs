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
    public class ViewModelToViewConverter : MarkupExtension, IValueConverter
    {
        private static readonly Dictionary<Type, Type> pairs = new Dictionary<Type, Type>()
        {
            {typeof(GameViewModel),typeof(GameView)},
            {typeof(OptionsViewModel),typeof(OptionsView)},
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;

            pairs.TryGetValue(value.GetType(), out var viewType);
            FrameworkElement view = (FrameworkElement)App.ServiceProvider.GetRequiredService(viewType);
            view.DataContext = value;
            return view;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Debugger.IsAttached)
                Debugger.Break();
            return DependencyProperty.UnsetValue;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
