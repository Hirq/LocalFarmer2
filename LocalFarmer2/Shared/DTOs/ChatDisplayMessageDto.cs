namespace LocalFarmer2.Shared.DTOs
{
    public class ChatDisplayMessageDto
    {
        public List<MonthDto> Months { get; set; }
    }

    public class MonthDto
    {
        public string Name { get; set; }
        public int Month { get; set; }
        public List<int> Days { get; set; }
    }
}

