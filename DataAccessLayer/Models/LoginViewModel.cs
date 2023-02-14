using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataAccessLayer.Models;

[ExcludeFromCodeCoverage]
public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [PasswordPropertyText]
    public string? Password { get; set; }
}