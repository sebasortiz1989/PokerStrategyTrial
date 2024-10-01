using System.Reflection;
using LibVLCSharp.Shared;

namespace PokerStrategyTrial.ViewModels.ViewModels;

public class SoundViewModel : ViewModelBase, IDisposable
{
    private readonly LibVLC _libVlc = new LibVLC();

    public SoundViewModel()
    {
        MediaPlayer = new MediaPlayer(_libVlc);
    }

    public MediaPlayer MediaPlayer { get; }

    public void Play()
    {
        // using var media = new Media(_libVlc, SoundResource.pokerchips1);
        // MediaPlayer.Play(media);
    }
        
    public void Stop()
    {            
        MediaPlayer.Stop();
    }
   
    public void Dispose()
    {
        MediaPlayer?.Dispose();
        _libVlc?.Dispose();
    }
}