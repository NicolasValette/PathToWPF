using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Names
{
    class IsInferiorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && parameter is string compare && value is double val)
            {
                if (double.TryParse(compare, NumberStyles.Float, culture.NumberFormat, out double tmp))
                {
                    return val <= tmp;
                }
            }
            return false;
        }
    

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
