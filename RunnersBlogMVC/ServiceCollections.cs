using RunnersBlogMVC.Services.LoginServices;
using RunnersBlogMVC.Services.RoleServices;
using RunnersBlogMVC.Services.ItemsServices;
using RunnersBlogMVC.Services.UserService;
using System.Diagnostics.CodeAnalysis;
using RunnersBlogMVC.Services.ProfileServices;

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

            builder.Services.AddControllersWithViews();

            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IItemsService, ItemsService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<IRoleService, RoleService>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Home/AccessDenied");
            });

            builder.Services.AddHttpContextAccessor();
        }
    }
}
