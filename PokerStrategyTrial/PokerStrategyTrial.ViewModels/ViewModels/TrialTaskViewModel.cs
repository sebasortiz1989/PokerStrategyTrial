using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Media;
using PokerStrategyTrial.ViewModels.ComponentModels;
using ReactiveUI;

namespace PokerStrategyTrial.ViewModels.ViewModels
{
    public class TrialTaskViewModel : ViewModelBase
    {
        private readonly string[] _cards = ["A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2"];
        private readonly Color[] _colors = [Color.Parse("#FFCA876A"), Color.Parse("#FFAB725A"), Color.Parse("#FF825744"), Color.Parse("#FF7D4B35"), Color.Parse("#FF5D3625")];

        public TrialTaskViewModel()
        {
            CommandReloadColors = ReactiveCommand.Create<object>(Execute);
            CreateHandStrategies();
        }

        public ReactiveCommand<object, Unit> CommandReloadColors { get; }

        public ObservableCollection<HandStrategyModel> HandStrategies { get; private set; } = new();

        public string TestOutput { get; set; } = "Clicked Button information";

        private void Execute(object parameter)
        {
            TestOutput = "Button Clicked!";
        }

        private void CreateHandStrategies()
        {
            Random rnd = new Random();

            for (int i = 0; i < _cards.Length; i++)
            {
                for (int j = 0; j < _cards.Length; j++)
                {
                    int numberOfStrategies = rnd.Next(1, _colors.Length - 1);
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

                    HandStrategyModel strategy = new HandStrategyModel(
                        hand: $"{_cards[i]}{_cards[j]}{(i == j ? string.Empty : i > j ? "o" : "s")}",
                        rnd.NextSingle() * 55,
                        strategiesFrequency.ToArray(),
                        _colors[new Range(0, numberOfStrategies)]);

                    HandStrategies.Add(strategy);
                }
            }
        }
    }
}