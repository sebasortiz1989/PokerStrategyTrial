using Microsoft.Extensions.DependencyInjection;
using PokerStrategyTrial.Services.Services;
using PokerStrategyTrial.ViewModels.ViewModels;

namespace PokerStrategyTrial.ViewModels.Container;

public class ViewModelProvider
{
    private static ViewModelProvider? instance;
    private ServiceCollection services = new();
    private ServiceProvider? serviceProvider;

    public ViewModelProvider()
    {
        RegisterServices();
        RegisterViewModels();
        serviceProvider = services.BuildServiceProvider();
    }

    public static ViewModelProvider Instance => instance ??= new ViewModelProvider();

    public ViewModelBase? GetViewModel(Type viewModelType)
    {
        var viewModel = serviceProvider?.GetService(viewModelType);
        if (viewModel is ViewModelBase viewModelSingleton)
        {
            return viewModelSingleton;       
        }

        return null;
    }
    
    private void RegisterViewModels()
    {
        services.AddTransient<TourPopupViewModel, TourPopupViewModel>();
        services.AddSingleton<MainViewModel, MainViewModel>();
        services.AddSingleton<StrategyViewModel, StrategyViewModel>();
        services.AddSingleton<SoundViewModel, SoundViewModel>();
    }

    private void RegisterServices()
    {
        services.AddSingleton<ISoundManagerService, SoundManagerService>();
    }
}