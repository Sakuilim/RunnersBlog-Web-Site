using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using RunnersBlogMVC.Services.RoleServices;

namespace DataAccessLayer.Controllers
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
