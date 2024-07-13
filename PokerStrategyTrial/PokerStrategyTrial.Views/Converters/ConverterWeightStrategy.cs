using System;
using System.Globalization;
using Avalonia.Data.Converters;
using PokerStrategyTrial.ViewModels.ComponentModels;

namespace PokerStrategyTrial.Views.Converters;

public class ConverterWeightStrategy : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not HandStrategyModel model || parameter is not string param)
            return 0;
        
        if (!double.TryParse(param, out var height))
        {
            return 0;
        }

        return model.Weight * height;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}