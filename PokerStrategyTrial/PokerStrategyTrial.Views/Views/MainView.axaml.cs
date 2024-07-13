using Avalonia.Controls;
using PokerStrategyTrial.Views.Container;

namespace PokerStrategyTrial.Views.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        ContentShown.Content = ViewProvider.Instance.GetView(typeof(TrialTaskView));
    }
}