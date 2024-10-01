using System;
using Avalonia.Controls;
using Avalonia.Input;

namespace PokerStrategyTrial.Views.Views;

public partial class InitialView : UserControl
{
    public InitialView()
    {
        InitializeComponent();
    }

    public event Action<ViewsEnum>? ShowViewAction;

    private void StrategyViewButton_OnTapped(object? sender, TappedEventArgs e)
    {
        ShowViewAction?.Invoke(ViewsEnum.StrategyScreen);
    }

    private void TourViewButton_OnTapped(object? sender, TappedEventArgs e)
    {
        ShowViewAction?.Invoke(ViewsEnum.TourView);
    }

    private void SoundsViewButton_OnTapped(object? sender, TappedEventArgs e)
    {
        ShowViewAction?.Invoke(ViewsEnum.SoundView);
    }
}