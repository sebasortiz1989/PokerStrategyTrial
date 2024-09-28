using System;
using Avalonia.Controls;
using Avalonia.Input;

namespace PokerStrategyTrial.Views.Views;

public partial class TourView : UserControl
{
    public TourView()
    {
        InitializeComponent();
    }

    public Action<ViewsEnum>? ShowViewAction { get; set; }

    private void BackButton_OnTapped(object? sender, TappedEventArgs e)
    {
        ShowViewAction?.Invoke(ViewsEnum.InitialView);
    }
}