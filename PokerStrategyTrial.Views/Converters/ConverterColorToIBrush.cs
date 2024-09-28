using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace PokerStrategyTrial.Views.Converters;

public class ConverterColorToIBrush : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (parameter is not string param || !int.TryParse(param, out var index) || value is not Color[] colors || colors.Length <= index)
            return Brushes.Black;

        return new SolidColorBrush(colors[index]);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}