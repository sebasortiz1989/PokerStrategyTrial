using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace PokerStrategyTrial.Views.Components;

public class ButtonStrategy : Button
{
    private float[] strategy;
    private Color[] strategyColors;
    private float weightValue;
    private bool showBoldFont;
    private string handName = "AA";

    public static readonly DirectProperty<ButtonStrategy, float[]> StrategyProperty =
        AvaloniaProperty.RegisterDirect<ButtonStrategy, float[]>(
            nameof(Strategy),
            o => o.Strategy,
            (o, v) => o.Strategy = v);

    public static readonly DirectProperty<ButtonStrategy, string> HandNameProperty =
        AvaloniaProperty.RegisterDirect<ButtonStrategy, string>(
            nameof(HandName),
            o => o.HandName,
            (o, v) => o.HandName = v);

    public static readonly DirectProperty<ButtonStrategy, float> WeightValueProperty =
        AvaloniaProperty.RegisterDirect<ButtonStrategy, float>(
            nameof(WeightValue),
            o => o.WeightValue,
            (o, v) => o.WeightValue = v);    

    public static readonly DirectProperty<ButtonStrategy, Color[]> StrategyColorsProperty =
        AvaloniaProperty.RegisterDirect<ButtonStrategy, Color[]>(
            nameof(StrategyColors),
            o => o.StrategyColors,
            (o, v) => o.StrategyColors = v);

    public static readonly DirectProperty<ButtonStrategy, bool> ShowBoldFontProperty =
        AvaloniaProperty.RegisterDirect<ButtonStrategy, bool>(
            nameof(ShowBoldFont),
            o => o.ShowBoldFont,
            (o, v) => o.ShowBoldFont = v);

    static ButtonStrategy()
    {
        HandNameProperty.Changed.AddClassHandler<ButtonStrategy>((sender, e) => HandNamePropertyChanged(sender, e));
    }

    public float[] Strategy
    {
        get => strategy;
        set => SetAndRaise(StrategyProperty, ref strategy, value);
    }

    public string HandName
    {
        get => handName;
        set => SetAndRaise(HandNameProperty, ref handName, value);
    }

    public float WeightValue
    {
        get => weightValue;
        set => SetAndRaise(WeightValueProperty, ref weightValue, value);
    }    

    public Color[] StrategyColors
    {
        get => strategyColors;
        set => SetAndRaise(StrategyColorsProperty, ref strategyColors, value);
    }

    public bool ShowBoldFont
    {
        get => showBoldFont;
        set => SetAndRaise(ShowBoldFontProperty, ref showBoldFont, value);
    }

    private static void HandNamePropertyChanged(ButtonStrategy sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property.Name != nameof(HandName))
            return;

        if (sender.HandName is { Length: > 1 } && sender.HandName[0] == sender.HandName[1])
        {
            sender.ShowBoldFont = true;
        }
    }
}