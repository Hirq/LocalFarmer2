namespace LocalFarmer2.Shared.Utilities
{
    public class FaqItem
    {
        public string Id { get; set; }
        public Dictionary<string, string> Question { get; set; }
        public Dictionary<string, string> Answer { get; set; }
    }
}
