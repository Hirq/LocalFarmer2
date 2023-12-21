namespace LocalFarmer2.Client.Services
{
    public class AlertService
    {
        public event Action OnAlert;
        public bool IsSuccessAlert { get; set; }
        public bool IsDeleteAlert { get; set; }
        public string Text { get; set; }

        public void SetSuccessAlert(string text)
        {
            IsSuccessAlert = true;
            IsDeleteAlert = false;
            Text = text;
            OnAlert?.Invoke();
        }

        public void SetDeleteAlert(string text)
        {
            IsSuccessAlert = false;
            IsDeleteAlert = true;
            Text = text;
            OnAlert?.Invoke();
        }
    }
}
