using System;
using System.Globalization;
using System.Windows.Data;

namespace STO.Model.Converters
{
    public class ServiceCostConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool IsChecked  = (bool)values[0];
            int Cost = (int)values[1];

            if (!IsChecked) Cost *= -1;

            return Cost;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
