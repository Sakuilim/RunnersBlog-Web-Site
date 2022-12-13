using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Services.RoleServices;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace RunnersBlogMVC.Controllers
{
    [ExcludeFromCodeCoverage]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        public IActionResult CreateRoleAsync()
        {
            return View();
        }
        //Post: User/CreateRole
        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole([Required][EmailAddress] string email, UserRole userRole)
        {
            return await roleService.CreateRole(email, userRole);
        }
    }
}
