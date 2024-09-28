using Avalonia.Controls;
using PokerStrategyTrial.Views.Container;

namespace PokerStrategyTrial.Views.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        ((InitialView)ViewProvider.Instance.GetView(typeof(InitialView))!).ShowViewAction += ShowScreenActionFunction;
        ((StrategyView)ViewProvider.Instance.GetView(typeof(StrategyView))!).ShowViewAction += ShowScreenActionFunction;
        ((TourView)ViewProvider.Instance.GetView(typeof(TourView))!).ShowViewAction += ShowScreenActionFunction;
        ShowScreenActionFunction(ViewsEnum.InitialView);
    }
    
    private void ShowScreenActionFunction(ViewsEnum tela)
    {
        switch (tela)
        {
            case ViewsEnum.InitialView:
                ContentView.Content = ViewProvider.Instance.GetView(typeof(InitialView));
                break;
            case ViewsEnum.StrategyScreen:
                ContentView.Content = ViewProvider.Instance.GetView(typeof(StrategyView));
                break;
            case ViewsEnum.TourView:
                ContentView.Content = ViewProvider.Instance.GetView(typeof(TourView));
                break;
        }
    }
}