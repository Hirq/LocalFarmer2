﻿namespace LocalFarmer2.Shared.DTOs
{
    public class EmailDto
    {
        public string From { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
    }
}
