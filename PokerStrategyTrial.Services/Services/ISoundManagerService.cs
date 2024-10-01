using LibVLCSharp.Shared;

namespace PokerStrategyTrial.Services.Services;

public interface ISoundManagerService : IDisposable
{
    void PlayFromUriPath(string soundName);
    void PlayFromPath(string soundPath);
    void PlayFromSoundDictionary(string soundKey);
    bool TryAddMediaToSoundDictionary(string soundKey, string mediaPath);
    void Pause();
    void Stop();
    void SetVolume(int volume);
    bool IsPlaying();
}