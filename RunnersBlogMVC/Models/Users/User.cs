using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RunnersBlogMVC.Models
{
    public class User
    {
        [Required(ErrorMessage = "Sorry the email is invalid")]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [EnumDataType(typeof(UserRole))]
        public string Role { get; set; }
    }
    public enum UserRole
    {
        Admin,
        User
    }
}
