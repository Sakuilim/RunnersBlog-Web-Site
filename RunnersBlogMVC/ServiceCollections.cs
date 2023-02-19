using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using RunnersBlogMVC.Services.LoginServices;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Models;
using RunnersBlogMVC.Data;
using DataAccessLayer.Repositories.DataAccess;
using DataAccessLayer.Data;
using RunnersBlogMVC.Services.ItemsServices;
using RunnersBlogMVC.Services.ProfileServices;
using RunnersBlogMVC.Services.UserService;
using RunnersBlogMVC.Services.RoleServices;
using DataAccessLayer.Repositories;

namespace RunnersBlogMVC
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollections
    {
        public static void SetupCollection(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();

            services.AddSession();

            services.AddControllersWithViews();

            services.AddSwaggerGen();

            services.AddScoped<ISqlDataAccess, SqlDataAccess>()
                    .AddScoped<IItemsData, ItemsData>();

            services.AddScoped<IItemsService, ItemsService>();

            services.AddScoped<IProfileService, ProfileService>()
                    .AddScoped<IUserService, UserService>()
                    .AddScoped<ILoginService, LoginService>()
                    .AddScoped<IRoleService, RoleService>();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Home/AccessDenied");
            });

            services.AddHttpContextAccessor();
        }
    }
}
