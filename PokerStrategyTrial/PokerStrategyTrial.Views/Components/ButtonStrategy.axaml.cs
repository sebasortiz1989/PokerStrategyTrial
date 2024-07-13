using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace PokerStrategyTrial.Views.Components;

public class ButtonStrategy : Button
{
    private float[]? strategy;
    private float? weight;
    private string? handName = "AA";

    public static readonly DirectProperty<ButtonStrategy, float[]?> StrategyProperty =
        AvaloniaProperty.RegisterDirect<ButtonStrategy, float[]?>(
            nameof(Strategy),
            o => o.Strategy,
            (o, v) => o.Strategy = v);

    public static readonly DirectProperty<ButtonStrategy, string?> HandNameProperty =
        AvaloniaProperty.RegisterDirect<ButtonStrategy, string?>(
            nameof(HandName),
            o => o.HandName,
            (o, v) => o.HandName = v);

    public static readonly DirectProperty<ButtonStrategy, float?> WeightProperty =
        AvaloniaProperty.RegisterDirect<ButtonStrategy, float?>(
            nameof(Weight),
            o => o.Weight,
            (o, v) => o.Weight = v);

    public ButtonStrategy()
    {
    }

    public float[]? Strategy
    {
        get => strategy;
        set => SetAndRaise(StrategyProperty, ref strategy, value);
    }

    public string? HandName
    {
        get => handName;
        set => SetAndRaise(HandNameProperty, ref handName, value);
    }

    public float? Weight
    {
        get => weight;
        set => SetAndRaise(WeightProperty, ref weight, value);
    }
}