﻿using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.DTOs
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CountAll { get; set; }

        [Required]
        public string CountMinOne { get; set; }

        [Required]
        public string PrizeOne { get; set; }
    }
}
