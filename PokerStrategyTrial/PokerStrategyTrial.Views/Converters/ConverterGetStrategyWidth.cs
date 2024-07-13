using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace PokerStrategyTrial.Views.Converters;

public class ConverterGetStrategyWidth : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (parameter is not string param)
            return 0;
        
        if (!int.TryParse(param, out var index))
        {
            return 0;
        }

        if (value is not double[] values)
            return 0;
     
        if (values.Length < index)
            return values[index];

        return 0;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}