namespace PokerStrategyTrial.Services.Services;

public interface ISoundManagerService : IDisposable
{
    void PlayFromUriPath(string soundName);
    void PlayFromPath(string soundPath);
    void Pause();
    void Stop();
    void SetVolume(int volume);
    bool IsPlaying();
}