using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using LibVLCSharp.Shared;
using PokerStrategyTrial.Services;
using PokerStrategyTrial.ViewModels.Container;
using PokerStrategyTrial.ViewModels.ViewModels;
using PokerStrategyTrial.Views.Assets;

namespace PokerStrategyTrial.Views.Views;

public partial class SoundView : UserControl
{
    private readonly SoundViewModel _viewModel;

    public SoundView()
    {
        DataContext = ViewModelProvider.Instance.GetViewModel(typeof(SoundViewModel));
        _viewModel = (SoundViewModel)DataContext!;

        InitializeComponent();

        AddAllSounds();
    }

    public Action<ViewsEnum>? ShowViewAction { get; set; }

    private void BackButton_OnTapped(object? sender, TappedEventArgs e)
    {
        ShowViewAction?.Invoke(ViewsEnum.InitialView);
        _viewModel?.SoundManagerService.Stop();
    }

    private void AddAllSounds()
    {
        _viewModel.SoundManagerService.TryAddMediaToSoundDictionary("playingCards", SoundResource.playingcards, extension: SoundExtension.mp3);
        _viewModel.SoundManagerService.TryAddMediaToSoundDictionary("music", SoundResource.music, extension: SoundExtension.mp3);
        _viewModel.SoundManagerService.TryAddMediaToSoundDictionary("pokerchips", SoundResource.pokerchips, extension: SoundExtension.wav);
        _viewModel.SoundManagerService.TryAddMediaToSoundDictionary("shufflecards", SoundResource.shufflecards, extension: SoundExtension.wav);
    }

    private void Button1_OnClick(object? sender, RoutedEventArgs e)
    {
        _viewModel?.SoundManagerService.Play("playingCards");
    }

    private void Button2_OnClick(object? sender, RoutedEventArgs e)
    {
        _viewModel?.SoundManagerService.Play("pokerchips");
    }

    private void Button3_OnClick(object? sender, RoutedEventArgs e)
    {
        _viewModel?.SoundManagerService.Play("shufflecards");
    }

    private void Button4_OnClick(object? sender, RoutedEventArgs e)
    {
        _viewModel?.SoundManagerService.Play("music");
    }
}