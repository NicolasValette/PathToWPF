using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Names
{
    public class ColorToARGB : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = string.Empty;
            if (value is Color c)
            {
               s = $"#{c.A:X2}{c.R:X2}{c.G:X2}{c.B:X2}";
            }
            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color c = (Color)ColorConverter.ConvertFromString(value.ToString());
            return c;
        }
    }
}
