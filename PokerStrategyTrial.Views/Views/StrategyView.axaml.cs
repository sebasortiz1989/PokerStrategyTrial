using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using PokerStrategyTrial.ViewModels.ComponentModels;
using PokerStrategyTrial.ViewModels.Container;
using PokerStrategyTrial.ViewModels.ViewModels;
using PokerStrategyTrial.Views.Components;

namespace PokerStrategyTrial.Views.Views;

public partial class StrategyView : UserControl
{
    private StrategyViewModel? _viewModel;

    public StrategyView()
    {
        DataContext = ViewModelProvider.Instance.GetViewModel(typeof(StrategyViewModel));
        if (DataContext is StrategyViewModel testViewModel)
            _viewModel = testViewModel;

        InitializeComponent();
    }

    public event Action<ViewsEnum>? ShowViewAction;

    private void ButtonStrategy_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not ButtonStrategy { DataContext: HandStrategyModel vm } button)
            return;

        _viewModel?.SetCardInformation(vm);
    }

    private void BackButton_OnTapped(object? sender, TappedEventArgs e)
    {
        ShowViewAction?.Invoke(ViewsEnum.InitialView);
    }
}