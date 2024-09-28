using System;
using System.Globalization;
using Avalonia.Data.Converters;
using PokerStrategyTrial.ViewModels.ComponentModels;

namespace PokerStrategyTrial.Views.Converters;

public class ConverterHeightStrategy : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (parameter is not string param)
            return 0;

        var heightAndIndex = param.Split('-');
        if (!float.TryParse(heightAndIndex[0], out var height) ||
            !int.TryParse(heightAndIndex[1], out var index) ||
            value is not float[] values)
        {
            return 0;
        }

        if (values.Length > index)
        {
            return values[index] * height;
        }

        return 0;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}