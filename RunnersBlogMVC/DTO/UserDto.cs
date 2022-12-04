using RunnersBlogMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace RunnersBlogMVC.DTO
{
    public record UserDto
    {
        [Required]
        public string? Name { get; init; }
        [Required]
        public UserRole Role { get; init; }
    }
}
