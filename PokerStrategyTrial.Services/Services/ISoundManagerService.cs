using LibVLCSharp.Shared;

namespace PokerStrategyTrial.Services.Services;

public interface ISoundManagerService : IDisposable
{
    void Play(string soundKey);
    Task<bool> TryAddMediaToSoundDictionary(string soundKey, byte[] sound, SoundExtension extension);
    Task<bool> TryAddMediaToSoundDictionary(string soundKey, UnmanagedMemoryStream soundStream, SoundExtension extension);
    void Pause();
    void Stop();
    void SetVolume(int volume);
    bool IsPlaying();
}