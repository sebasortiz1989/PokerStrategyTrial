using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using MicrophoneApp.ViewModel.Container;
using PokerStrategyTrial.ViewModels.ComponentModels;
using PokerStrategyTrial.ViewModels.ViewModels;
using PokerStrategyTrial.Views.Components;

namespace PokerStrategyTrial.Views.Views;

public partial class TrialTaskView : UserControl
{
    private TrialTaskViewModel? _viewModel;

    public TrialTaskView()
    {
        DataContext = ViewModelProvider.Instance.GetViewModel(typeof(TrialTaskViewModel));
        if (DataContext is TrialTaskViewModel testViewModel)
            _viewModel = testViewModel;

        InitializeComponent();
    }

    private void ButtonStrategy_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not ButtonStrategy { DataContext: HandStrategyModel vm } button)
            return;

        _viewModel?.SetCardInformation(vm);
    }
}