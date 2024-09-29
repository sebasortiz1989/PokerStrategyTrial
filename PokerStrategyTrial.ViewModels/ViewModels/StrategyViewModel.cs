using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Media;
using PokerStrategyTrial.ViewModels.ComponentModels;
using ReactiveUI;

namespace PokerStrategyTrial.ViewModels.ViewModels
{
    public class StrategyViewModel : ViewModelBase
    {
        private readonly string[] _cards = ["A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2"];
        private readonly Color[] _colors = [Color.Parse("#FFCA876A"), Color.Parse("#FFAB725A"), Color.Parse("#FF825744"), Color.Parse("#FF7D4B35"), Color.Parse("#FF5D3625")];

        public StrategyViewModel()
        {
            CommandClearInfo = ReactiveCommand.Create<object>(FunctionClearInfo);
            CreateHandStrategies();
        }

        public ReactiveCommand<object, Unit> CommandClearInfo { get; }

        public ObservableCollection<HandStrategyModel> HandStrategies { get; } = new();

        public string HandNameInfoCard { get; set; }
        public string WeightInfoCard { get; set; }
        public string StrategyInfoCard { get; set; }
        public string ColorsInfoCard { get; set; }

        public void SetCardInformation(HandStrategyModel model)
        {
            HandNameInfoCard = "Hand: " + model.Hand;
            WeightInfoCard = $"Weight: {float.Round(model.Weight * 100, 1)}%";
            StrategyInfoCard = $"Strategy: \n{ string.Join("% - ", model.Strategy.Select(x => float.Round(x * 100, 1))) }%";
            ColorsInfoCard = $"Colors: \n{ string.Join("", model.StrategyColors.Select(x => $"A{x.A}-R{x.R}-B{x.B}-G{x.G}\n")) }";
        }

        private void FunctionClearInfo(object parameter)
        {
            HandNameInfoCard = string.Empty;
            WeightInfoCard = string.Empty;
            StrategyInfoCard = string.Empty;
            ColorsInfoCard = string.Empty;
        }

        private void CreateHandStrategies()
        {
            Random rnd = new Random();

            for (int i = 0; i < _cards.Length; i++)
            {
                for (int j = 0; j < _cards.Length; j++)
                {
                    int numberOfStrategies = rnd.Next(1, _colors.Length + 1);
                    Collection<float> strategiesFrequency = [];
                    float sumOfFrequencies = 0;
                    for (int z = 0; z < numberOfStrategies; z++)
                    {
                        if (z == numberOfStrategies - 1)
                        {
                            strategiesFrequency.Add(1 - sumOfFrequencies);
                            break;
                        }

                        var newFrequency = rnd.NextSingle() * (1 - sumOfFrequencies);
                        strategiesFrequency.Add(newFrequency);
                        sumOfFrequencies += newFrequency;
                    }

                    string handName;
                    if (i == j)
                    {
                        handName = $"{_cards[i]}{_cards[j]}";
                    }
                    else if (i > j)
                    {
                        handName = $"{_cards[j]}{_cards[i]}o";
                    }
                    else
                    {
                        handName = $"{_cards[i]}{_cards[j]}s";
                    }

                    HandStrategyModel strategy = new HandStrategyModel(
                        hand: handName,
                        weight: rnd.NextSingle(),
                        strategy: strategiesFrequency.Order().ToArray(),
                        strategyColors: _colors[new Range(0, numberOfStrategies)]);

                    HandStrategies.Add(strategy);
                }
            }
        }
    }
}