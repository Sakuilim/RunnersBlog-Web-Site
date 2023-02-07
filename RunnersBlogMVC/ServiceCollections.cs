using System.Diagnostics.CodeAnalysis;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using RunnersBlogMVC.Services.LoginServices;

namespace RunnersBlogMVC
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollections
    {
        public static void SetupCollection(WebApplicationBuilder builder)
        {
            builder.Services.AddMvc(options =>
            {
                options.MaxModelBindingRecursionDepth = 64;
            });

            builder.Services.AddSession();

            builder.Services.AddIdentity<User, IdentityRole>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddSwaggerGen();

            //builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();
            //builder.Services.AddScoped<IUserData, UserData>();
            //builder.Services.AddScoped<IItemsService, ItemsService>();
            //builder.Services.AddScoped<IProfileService, ProfileService>();
            //builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ILoginService, LoginService>();
            //builder.Services.AddScoped<IRoleService, RoleService>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Home/AccessDenied");
            });

            builder.Services.AddHttpContextAccessor();
        }
    }
}
