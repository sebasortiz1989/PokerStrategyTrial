using PokerStrategyTrial.Services.Services;

namespace PokerStrategyTrial.ViewModels.ViewModels;

public class SoundViewModel : ViewModelBase
{
    public SoundViewModel(ISoundManagerService soundManagerService)
    {
        SoundManagerService = soundManagerService;
    }

    public ISoundManagerService SoundManagerService { get; }

    public void Dispose()
    {
        SoundManagerService?.Dispose();
    }
}