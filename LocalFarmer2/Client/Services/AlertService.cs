namespace LocalFarmer2.Client.Services
{
    public class AlertService
    {
        public bool IsSuccessAlert { get; set; }
        public bool IsDeleteAlert { get; set; }
        public string Text { get; set; }

        public void SetSuccessAlert(string text)
        {
            IsSuccessAlert = true;
            Text = text;
        }

        public void SetDeleteAlert(string text)
        {
            IsDeleteAlert = true;
            Text = text;
        }

    }
}
