﻿using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace RunnersBlogMVC.Services.RoleServices
{
    public interface IRoleService
    {
        public Task<IActionResult> CreateRole([Required][EmailAddress] string email, UserRole userRole);
        public Task<IActionResult> ShowAllRolesAsync();
    }
}
