using Microsoft.Extensions.DependencyInjection;
using PokerStrategyTrial.ViewModels.ViewModels;

namespace MicrophoneApp.ViewModel.Container;

public class ViewModelProvider
{
    private static ViewModelProvider? instance;
    private ServiceCollection services = new();
    private ServiceProvider? serviceProvider;

    public ViewModelProvider()
    {
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
        services.AddSingleton<MainViewModel, MainViewModel>();
        services.AddSingleton<StrategyViewModel, StrategyViewModel>();
    }
}