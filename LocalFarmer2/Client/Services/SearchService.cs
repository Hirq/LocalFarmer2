namespace LocalFarmer2.Client.Services
{
    public class SearchService
    {
        private string _searchString;

        public string SearchString
        {
            get => _searchString;
            set
            {
                if (_searchString != value)
                {
                    _searchString = value;
                    NotifySearchStringChanged();
                }
            }
        }

        public event Action OnSearchStringChanged;

        private void NotifySearchStringChanged() => OnSearchStringChanged?.Invoke();
    }
}
