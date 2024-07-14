using System;
using Avalonia.Controls;
using PokerStrategyTrial.Views.Container;

namespace PokerStrategyTrial.Views.Views;

public partial class MainView : UserControl
{
    private InitialView _initialView;
    private StrategyView _strategyView;

    public MainView()
    {
        InitializeComponent();
        _initialView = (InitialView)ViewProvider.Instance.GetView(typeof(InitialView))!;
        _strategyView = (StrategyView)ViewProvider.Instance.GetView(typeof(StrategyView))!;
        _initialView.ShowViewAction += ShowScreenActionFunction;
        _strategyView.ShowViewAction += ShowScreenActionFunction;

        InitialView.Content = _initialView;
        StrategyView.Content = _strategyView;
        ShowScreenActionFunction(ViewsEnum.InitialView);
    }
    
    private void ShowScreenActionFunction(ViewsEnum tela)
    {
        switch (tela)
        {
            case ViewsEnum.InitialView:
                InitialView.IsVisible = true;
                StrategyView.IsVisible = false;
                break;
            case ViewsEnum.StrategyScreen:
                StrategyView.IsVisible = true;
                InitialView.IsVisible = false;
                break;
        }
    }
}