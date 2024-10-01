using System;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using PokerStrategyTrial.Views.Views;
using PokerStrategyTrial.Views.Windows;

namespace PokerStrategyTrial.Views.Container;

public sealed class ViewProvider
{
    private static ViewProvider? instance;
    private ServiceCollection services = new();
    private ServiceProvider? serviceProvider;

    private ViewProvider()
    {
        RegisterViews();
        serviceProvider = services.BuildServiceProvider();
    }

    public static ViewProvider Instance => instance ??= new ViewProvider();

    public UserControl? GetView(Type viewType)
    {
        var view = serviceProvider?.GetService(viewType);
        if (view is UserControl viewSingleton)
        {
            return viewSingleton;       
        }

        return null;
    }
    
    private void RegisterViews()
    {
        services.AddSingleton<MainView, MainView>();
        services.AddSingleton<StrategyView, StrategyView>();
        services.AddSingleton<InitialView, InitialView>();
        services.AddSingleton<TourView, TourView>();
        services.AddSingleton<SoundView, SoundView>();
    }
}