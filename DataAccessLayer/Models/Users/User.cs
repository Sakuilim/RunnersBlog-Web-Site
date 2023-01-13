﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [EmailAddress]
        [Required(ErrorMessage = "Sorry the Email is invalid")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Sorry the Name is invalid")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Sorry the Password is invalid")]
        public string? Password { get; set; }
        [EnumDataType(typeof(UserRole))]
        public string? Role { get; set; } = UserRole.User.ToString();
    }
    public enum UserRole
    {
        Admin,
        User
    }
}