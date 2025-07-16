namespace IThubSAT.Shared;
public class TopBarState
{
    public string PageTitle { get; private set; } = "Главная";
    public string HrefBack { get; private set; } = string.Empty;
    public event Action OnChange;
    public void SetTopBarData(string title, string hrefBack = "")
    {
        PageTitle = title;
        HrefBack = hrefBack;
        NotifyStateChanged();
    }
    private void NotifyStateChanged() => OnChange?.Invoke();
}
