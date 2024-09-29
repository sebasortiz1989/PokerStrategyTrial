using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.VisualTree;
using PokerStrategyTrial.Views.Windows;

namespace PokerStrategyTrial.Views.Views;

public partial class TourView : UserControl
{
    public TourView()
    {
        InitializeComponent();
    }

    public Action<ViewsEnum>? ShowViewAction { get; set; }

    public Action<TourPopup?> ShowPopupAction { get; set; }

    private void BackButton_OnTapped(object? sender, TappedEventArgs e)
    {
        ShowViewAction?.Invoke(ViewsEnum.InitialView);
    }

    private void ShowPopupButton_OnTapped(object? sender, TappedEventArgs e)
    {
        if (Application.Current != null &&
            Application.Current.ApplicationLifetime is ClassicDesktopStyleApplicationLifetime lifetime)
        {
            if (lifetime.MainWindow != null)
            {
                var contentControl = lifetime.MainWindow.GetVisualDescendants().OfType<MainView>().First();
                contentControl.ShowSpecificPopup(PopupEnum.Popup1);
            }
        }
    }
}