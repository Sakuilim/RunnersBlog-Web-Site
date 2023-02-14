using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class User : IdentityUser
    {
        [EnumDataType(typeof(UserRole))]
        public string Role { get; set; } = UserRole.User.ToString();
        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public enum UserRole
    {
        Admin,
        User
    }
}
