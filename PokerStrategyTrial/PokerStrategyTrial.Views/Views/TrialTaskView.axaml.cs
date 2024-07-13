using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using MicrophoneApp.ViewModel.Container;
using PokerStrategyTrial.ViewModels.ViewModels;

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
}