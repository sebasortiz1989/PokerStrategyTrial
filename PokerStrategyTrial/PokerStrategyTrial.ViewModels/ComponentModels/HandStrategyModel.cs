using System.Collections.ObjectModel;
using Avalonia.Media;

namespace PokerStrategyTrial.ViewModels.ComponentModels;

public class HandStrategyModel
{
    public HandStrategyModel(string hand, float weight, double[] strategy, Color[] strategyColors)
    {
        Hand = hand;
        Weight = weight;
        Strategy = strategy;
        StrategyColors = strategyColors;
    }
    
    public string Hand { get; private set; }

    public float Weight { get; private set; }

    public double[] Strategy { get; private set; }

    public Color[] StrategyColors { get; private set; }
}