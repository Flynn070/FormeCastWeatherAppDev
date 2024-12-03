using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FormeCastWeatherApp.Converters
{
    internal class CurrentForecastWidth : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            double windowWidth = (Double)value[0];
            double windowHeight = (Double)value[1];
            double height = (windowHeight / 2) - 30;
            if (height > (windowWidth * 2 / 3) - 30){   //keep box at max half width and/or height if window (minus margins)
                height = (windowWidth * 2 / 3) - 30;
            }
            return height;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
