using Avalonia;

namespace PokerStrategyTrial.ViewModels.ViewModels;

public class TourPopupViewModel : ViewModelBase
{
    private Thickness _selectorPosition = new(0);
    private double _selectorWidth;
    private double _selectorHeight;

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

    public Thickness SelectorPosition
    {
        get => _selectorPosition;
        set
        {
            _selectorPosition = value;
            UpdateHoleRectangle();
        }
    }

    public double SelectorWidth
    {
        get => _selectorWidth;
        set
        {
            _selectorWidth = value;
            UpdateHoleRectangle();
        }
    }

    public double SelectorHeight
    {
        get => _selectorHeight;
        set
        {
            _selectorHeight = value;
            UpdateHoleRectangle();
        }
    }

    public Rect HoleRectangle { get; private set; }

    private void UpdateHoleRectangle()
    {
        HoleRectangle = new Rect(_selectorPosition.Left + 5, _selectorPosition.Top + 5, _selectorWidth - 10, _selectorHeight - 10);
    }
}