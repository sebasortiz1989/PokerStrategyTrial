using LibVLCSharp.Shared;

namespace PokerStrategyTrial.Services.Services;

public interface ISoundManagerService : IDisposable
{
    void Play(string soundKey);
    Task<bool> TryAddMediaToSoundDictionary(string soundKey, Uri soundUri);
    void Pause();
    void Stop();
    void SetVolume(int volume);
    bool IsPlaying();
}