﻿using RunnersBlogMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace RunnersBlogMVC.Models
{
    public record Item
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public decimal Price { get; init; }
        public string? Description { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
        public string? CreatedBy { get; init; }
        public string? ItemAvailabilityStatus { get; set; } = ItemStatus.Available.ToString();
        public Guid ReservedBy { get; set; }
    }

}
