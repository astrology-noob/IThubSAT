namespace IThubSAT.Data.SurveyPages
{
    public class ItemSelectionPage : SurveyPage
    {
        public List<FilterItem> AllItems = new();

        public int SelectedItemId = -1;

        public Func<int, Task> OnChooseItem;

    }
}
