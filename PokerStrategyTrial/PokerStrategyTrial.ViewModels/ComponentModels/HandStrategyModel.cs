using System.Collections.ObjectModel;
using Avalonia.Media;

namespace PokerStrategyTrial.ViewModels.ComponentModels;

public class HandStrategyModel
{
    public HandStrategyModel(string handName, float weight, float[] strategy, Color[] strategyColors)
    {
        Hand = handName;
        Weight = weight;
        Strategy = strategy;
        StrategyColors = strategyColors;
    }
    
    public string Hand { get; private set; }

    public float Weight { get; private set; }

    public float[] Strategy { get; private set; }

    public Color[] StrategyColors { get; private set; }
}