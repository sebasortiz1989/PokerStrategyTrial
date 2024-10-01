using LibVLCSharp.Shared;

namespace PokerStrategyTrial.Services.Services;

public class SoundManagerService : ISoundManagerService
{
    private readonly LibVLC _libVlc = new();
    private readonly MediaPlayer _mediaPlayer;
    private Media? _currentMedia;

    public SoundManagerService()
    {
        _mediaPlayer = new MediaPlayer(_libVlc);
    }
    
    public void Play(string soundName)
    {
        Stop();
        // _currentMedia = new Media()
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
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }
}