using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using PokerStrategyTrial.Views.Container;
using PokerStrategyTrial.Views.Windows;

namespace PokerStrategyTrial.Views.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        ((InitialView)ViewProvider.Instance.GetView(typeof(InitialView))!).ShowViewAction += ShowScreenActionFunction;
        ((StrategyView)ViewProvider.Instance.GetView(typeof(StrategyView))!).ShowViewAction += ShowScreenActionFunction;
        ((TourView)ViewProvider.Instance.GetView(typeof(TourView))!).ShowViewAction += ShowScreenActionFunction;
        ((TourView)ViewProvider.Instance.GetView(typeof(TourView))!).ShowPopupAction += ShowPopupActionFunction;
        ShowScreenActionFunction(ViewsEnum.InitialView);
        PopulateTourPopups();
    }

    public Dictionary<PopupEnum, TourPopup> TourPopups { get; } = new();

    public void ShowSpecificPopup(PopupEnum popup)
    {
        if (!TourPopups.TryGetValue(popup, out var tourPopup))
            return;

        ShowPopupActionFunction(tourPopup);
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

    private void ShowPopupActionFunction(TourPopup? popup)
    {
        PopupView.Content = popup;
    }

    private void PopulateTourPopups()
    {
        TourPopups.Add(PopupEnum.Popup1, new TourPopup
        {
            ViewModel =
            {
                PopupPageNumber = "1 of 3",
                PopupTitle = "Popup Title 1",
                PopupContent = "Popup Content 1",
                PopupPosition = new Thickness(490, 550),
                NextPopupIndex = 1,
                SelectorPosition = new Thickness(1000, 550),
                SelectorWidth = 900,
                SelectorHeight = 480,
            }
        });

        TourPopups.Add(PopupEnum.Popup2, new TourPopup
        {
            ViewModel =
            {
                PopupPageNumber = "2 of 3",
                PopupTitle = "Popup Title 2",
                PopupContent = "Popup Content 2",
                PopupPosition = new Thickness(90, 535),
                NextPopupIndex = 2,
                SelectorPosition = new Thickness(90, 305),
                SelectorWidth = 1815,
                SelectorHeight = 220,
            }
        });

        TourPopups.Add(PopupEnum.Popup3, new TourPopup
        {
            ViewModel =
            {
                PopupPageNumber = "3 of 3",
                PopupTitle = "Popup Title 3",
                PopupContent = "Popup Content 3",
                PopupPosition = new Thickness(1010, 540),
                SelectorPosition = new Thickness(90, 540),
                SelectorWidth = 910,
                SelectorHeight = 490,
            }
        });
    }
}