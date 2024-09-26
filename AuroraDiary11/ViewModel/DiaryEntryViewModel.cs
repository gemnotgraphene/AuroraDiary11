using AuroraDiary.Models;

public class DiaryEntryViewModel : BindableObject
{
    private bool _isButtonsVisible;
    private bool _isContentVisible;

    public DiaryEntry Entry { get; }

    public DiaryEntryViewModel(DiaryEntry entry)
    {
        Entry = entry;
    }

    public bool IsButtonsVisible
    {
        get => _isButtonsVisible;
        set
        {
            _isButtonsVisible = value;
            OnPropertyChanged();
        }
    }

    public bool IsContentVisible
    {
        get => _isContentVisible;
        set
        {
            _isContentVisible = value;
            OnPropertyChanged();
        }
    }

    public string Title => Entry.Title;
    public string Date => Entry.Date.ToString("MM/dd/yyyy");
    public string Content => Entry.Content;
    public string Emotion => Entry.Emotion;

    public ImageSource Photo
    {
        get
        {
            if (string.IsNullOrEmpty(Entry.Photo))
                return null;

            return ImageSource.FromStream(() => new System.IO.MemoryStream(Convert.FromBase64String(Entry.Photo)));
        }
    }
}
