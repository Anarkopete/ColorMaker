using System;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;

namespace ExpenseTracker.Converters
{
    public class IncomeColorConverter : IValueConverter
    {
        // Convierte la propiedad IsIncome a color: verde para ingresos, rojo para gastos
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool isIncome)
                return isIncome ? Colors.Green : Colors.Red;
            return Colors.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}