using System.Text;
using System.Windows.Input;
using PokerStrategyTrial.ViewModels.Utils;
using PropertyChanged;

namespace PokerStrategyTrial.ViewModels.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TrialTaskViewModel : ViewModelBase
    {
        public TrialTaskViewModel()
        {
            TestCommand = new SimpleCommand(FuncaoTest, true);
        }

        public string TestInput { get; set; }
        public string TestOutput { get; set; }
    
        public ICommand TestCommand { get; set; }

        public Task FuncaoTest()
        {
            if (TestInput == null || TestInput.Length == 0)
                return Task.CompletedTask;

            StringBuilder sb = new StringBuilder();
            int cont = 1;
            for (var i = 0; i < TestInput.Length; i++)
            {
                var currentChar = TestInput[i];

                if (i == 0)
                {
                    if (i == TestInput.Length - 1)
                    {
                        sb.Append($"{cont}{currentChar}");
                    }

                    continue;
                }
            
                var lastChar = TestInput[i - 1];

                if (currentChar == lastChar)
                {
                    cont++;
                }
                else
                {
                    sb.Append($"{cont}{lastChar}");
                    cont = 1;
                }

                if (i != TestInput.Length - 1) continue;

                sb.Append($"{cont}{currentChar}");
                cont = 0;
            }

            TestOutput = sb.ToString();

            return Task.CompletedTask;
        }
    }
}