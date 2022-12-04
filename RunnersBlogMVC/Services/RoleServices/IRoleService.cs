using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace RunnersBlogMVC.Services.RoleServices
{
    public interface IRoleService
    {
        public Task<IActionResult> CreateRole([Required][EmailAddress] string email, UserRole userRole);
    }
}
