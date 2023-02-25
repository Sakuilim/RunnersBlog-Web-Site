using DataAccessLayer.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.DTO;
public record ItemDto
{
    [Required]
    public string Name { get; init; }
    [Required]
    [Range(1, 1000)]
    public decimal Price { get; init; }
    [Required]
    public string Description { get; init; }
    [Required]
    public ItemStatus ItemAvailabilityStatus { get; init; }
}
