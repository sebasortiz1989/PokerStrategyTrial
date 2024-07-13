using System.Reactive;
using ReactiveUI;

namespace PokerStrategyTrial.ViewModels.ViewModels
{
    public class TrialTaskViewModel : ViewModelBase
    {
        public TrialTaskViewModel()
        {
            ExampleCommand = ReactiveCommand.Create<object>(Execute);
        }

        private void Execute(object parameter)
        {
            TestOutput = "Button Clicked!";
        }

        public string TestOutput { get; set; } = "Clicked Button information";

        public ReactiveCommand<object, Unit> ExampleCommand { get; }
    }
}