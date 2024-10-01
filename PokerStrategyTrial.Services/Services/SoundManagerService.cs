using LibVLCSharp.Shared;

namespace PokerStrategyTrial.Services.Services;

public class SoundManagerService : ISoundManagerService
{
    private readonly LibVLC _libVlc = new();
    private readonly MediaPlayer _mediaPlayer;
    private Media? _currentMedia;
    private Dictionary<string, Media> _mediaDictionary = new();

    public SoundManagerService()
    {
        _mediaPlayer = new MediaPlayer(_libVlc);
    }

    public void PlayFromUriPath(string soundUrl)
    {
        Stop();
        _currentMedia = new Media(_libVlc, new Uri(soundUrl));
        _mediaPlayer.Play(_currentMedia);
    }

    public void PlayFromPath(string soundPath)
    {
        Stop();
        _currentMedia = new Media(_libVlc, soundPath);
        _mediaPlayer.Play(_currentMedia);
    }

    public void PlayFromSoundDictionary(string soundKey)
    {
        Stop();
        if (_mediaDictionary.TryGetValue(soundKey, out _currentMedia))
        {
            _mediaPlayer.Play(_currentMedia);
        }
    }

    public bool TryAddMediaToSoundDictionary(string soundKey, string mediaPath)
    {
        return _mediaDictionary.TryAdd(soundKey, new Media(_libVlc, mediaPath));
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

        _currentMedia?.Dispose();
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