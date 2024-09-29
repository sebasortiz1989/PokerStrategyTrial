using Avalonia;

namespace PokerStrategyTrial.ViewModels.ViewModels;

public class TourPopupViewModel : ViewModelBase
{
    public void SetPopupValues(string page, string popupTitle, string popupContent, Thickness popupPositionMargin, int nextPopupIndex)
    {
        PopupPageNumber = page;
        PopupTitle = popupTitle;
        PopupContent = popupContent;
        PopupPosition = popupPositionMargin;
        NextPopupIndex = nextPopupIndex;
    }

    public string PopupTitle { get; set; } = string.Empty;
    
    public string PopupContent { get; set; } = string.Empty;

    public string PopupPageNumber { get; set; } = string.Empty;

    public Thickness PopupPosition { get; set; } = new(0);

    public int NextPopupIndex { get; set; }
}