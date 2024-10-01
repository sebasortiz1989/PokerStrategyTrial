namespace PokerStrategyTrial.Services.Services;

public interface ISoundManagerService : IDisposable
{
    void Play(string soundName);
    void Pause();
    void Stop();
    void SetVolume(int volume);
}