using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;
using PokerStrategyTrial.ViewModels.Container;
using PokerStrategyTrial.ViewModels.ViewModels;
using PokerStrategyTrial.Views.Views;

namespace PokerStrategyTrial.Views.Windows;

public partial class TourPopup : UserControl
{
    public TourPopup()
    {
        DataContext = ViewModel = (ViewModelProvider.Instance.GetViewModel(typeof(TourPopupViewModel)) as TourPopupViewModel)!;
        InitializeComponent();
    }

    public TourPopupViewModel ViewModel { get; private set; }

    private static MainView? GetMainViewInstance()
    {
        try
        {
            if (Application.Current != null &&
                Application.Current.ApplicationLifetime is ClassicDesktopStyleApplicationLifetime { MainWindow: not null } lifetime)
            {
                return lifetime.MainWindow.GetVisualDescendants().OfType<MainView>().First();
            }
        }
        catch (Exception)
        {
            return null;
        }

        return null;
    }

    private void SkipTourButton_OnClicked(object? sender, RoutedEventArgs routedEventArgs)
    {
        var mainView = GetMainViewInstance();
        if (mainView != null)
        {
            mainView.PopupView.Content = null;
        }
    }

    private void NextTourButton_OnClicked(object? sender, RoutedEventArgs routedEventArgs)
    {
        var mainView = GetMainViewInstance();
        mainView?.ShowSpecificPopup((PopupEnum)ViewModel.NextPopupIndex);
    }
}