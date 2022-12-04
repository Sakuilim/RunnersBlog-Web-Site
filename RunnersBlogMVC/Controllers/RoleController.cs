using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Services.RoleServices;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace RunnersBlogMVC.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        //Post: User/CreateRole
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole([Required][EmailAddress] string email, UserRole userRole)
        {
            IActionResult result = email is null ? View() : await roleService.CreateRole(email, userRole);
            return result;
        }
    }
}
