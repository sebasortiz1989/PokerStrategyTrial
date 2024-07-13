using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace PokerStrategyTrial.Views.Components;

public class ButtonStrategy : Button
{
    private double[] strategy;
    private Color[] strategyColors;
    private double weightValue;
    private string handName = "AA";

    public static readonly DirectProperty<ButtonStrategy, double[]> StrategyProperty =
        AvaloniaProperty.RegisterDirect<ButtonStrategy, double[]>(
            nameof(Strategy),
            o => o.Strategy,
            (o, v) => o.Strategy = v);

    public static readonly DirectProperty<ButtonStrategy, string> HandNameProperty =
        AvaloniaProperty.RegisterDirect<ButtonStrategy, string>(
            nameof(HandName),
            o => o.HandName,
            (o, v) => o.HandName = v);

    public static readonly DirectProperty<ButtonStrategy, double> WeightValueProperty =
        AvaloniaProperty.RegisterDirect<ButtonStrategy, double>(
            nameof(WeightValue),
            o => o.WeightValue,
            (o, v) => o.WeightValue = v);    

    public static readonly DirectProperty<ButtonStrategy, Color[]> StrategyColorsProperty =
        AvaloniaProperty.RegisterDirect<ButtonStrategy, Color[]>(
            nameof(StrategyColors),
            o => o.StrategyColors,
            (o, v) => o.StrategyColors = v);

    public ButtonStrategy()
    {
        
    }

    public double[] Strategy
    {
        get => strategy;
        set => SetAndRaise(StrategyProperty, ref strategy, value);
    }

    public string HandName
    {
        get => handName;
        set => SetAndRaise(HandNameProperty, ref handName, value);
    }

    public double WeightValue
    {
        get => weightValue;
        set => SetAndRaise(WeightValueProperty, ref weightValue, value);
    }    

    public Color[] StrategyColors
    {
        get => strategyColors;
        set => SetAndRaise(StrategyColorsProperty, ref strategyColors, value);
    }
}