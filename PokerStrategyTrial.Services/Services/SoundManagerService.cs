using LibVLCSharp.Shared;

namespace PokerStrategyTrial.Services.Services;

public class SoundManagerService : ISoundManagerService
{
    private readonly LibVLC _libVlc = new();
    private readonly MediaPlayer _mediaPlayer;
    private readonly Dictionary<string, Media> _mediaDictionary = new();
    private Media? _currentMedia;

    public SoundManagerService()
    {
        _mediaPlayer = new MediaPlayer(_libVlc);
    }

    public void Play(string soundKey)
    {
        Stop();
        if (!_mediaDictionary.TryGetValue(soundKey, out _currentMedia))
            return;

        _mediaPlayer.Play(_currentMedia);
    }

    public async Task<bool> TryAddMediaToSoundDictionary(string soundKey, byte[] sound, SoundExtension extension)
    {
        if (sound == null)
            return false;

        string tempFilePath = Path.Combine(Path.GetTempPath(), soundKey + "." + Enum.GetName(extension));
        if (!File.Exists(tempFilePath))
        {
            await File.WriteAllBytesAsync(tempFilePath, sound);
        }

        var media = new Media(_libVlc, new Uri(tempFilePath));
        return _mediaDictionary.TryAdd(soundKey, media);
    }

    public async Task<bool> TryAddMediaToSoundDictionary(string soundKey, UnmanagedMemoryStream soundStream, SoundExtension extension)
    {
        long length = soundStream.Length;
        byte[] sound = new byte[length];
        _ = soundStream.Read(sound, 0, (int)length);

        string tempFilePath = Path.Combine(Path.GetTempPath(), soundKey + "." + Enum.GetName(extension));
        if (!File.Exists(tempFilePath))
        {
            await File.WriteAllBytesAsync(tempFilePath, sound);
        }

        var media = new Media(_libVlc, new Uri(tempFilePath));
        return _mediaDictionary.TryAdd(soundKey, media);
    }

    public void Pause()
    {
        if (_mediaPlayer.IsPlaying)
        {
            _mediaPlayer.Pause();
        }
    }

    public void Stop()
    {
        if (_mediaPlayer.IsPlaying)
        {
            _mediaPlayer.Stop();
        }

        _currentMedia = null;
    }

    public void SetVolume(int volume)
    {
        _mediaPlayer.Volume = Math.Clamp(volume, 0, 100);
    }

    public bool IsPlaying() => _mediaPlayer.IsPlaying;

    public void Dispose()
    {
        _mediaPlayer.Dispose();
        _currentMedia?.Dispose();
    }
}