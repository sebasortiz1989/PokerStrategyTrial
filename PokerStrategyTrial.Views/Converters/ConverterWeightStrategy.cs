using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace PokerStrategyTrial.Views.Converters;

public class ConverterWeightStrategy : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (parameter is not string param || !float.TryParse(param, out var height) || value is not float weight)
            return 0;

        return weight * height;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}