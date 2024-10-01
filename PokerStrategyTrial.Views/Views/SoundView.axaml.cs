using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using PokerStrategyTrial.ViewModels.Container;
using PokerStrategyTrial.ViewModels.ViewModels;

namespace PokerStrategyTrial.Views.Views;

public partial class SoundView : UserControl
{
    private readonly SoundViewModel _viewModel;

    public SoundView()
    {
        DataContext = ViewModelProvider.Instance.GetViewModel(typeof(SoundViewModel));
        if (DataContext is SoundViewModel testViewModel)
            _viewModel = testViewModel;

        InitializeComponent();
    }

    public Action<ViewsEnum>? ShowViewAction { get; set; }

    private void BackButton_OnTapped(object? sender, TappedEventArgs e)
    {
        ShowViewAction?.Invoke(ViewsEnum.InitialView);
    }

    private void Button1_OnClick(object? sender, RoutedEventArgs e)
    {
        if (_viewModel.MediaPlayer.IsPlaying)
        {
            _viewModel.Stop();
        }
        else
        {
            _viewModel.Play();
        }
    }
}