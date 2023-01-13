using DataAccessLayer.Services.LoginServices;
using DataAccessLayer.Services.RoleServices;
using DataAccessLayer.Settings;
using DataAccessLayer.Services.ItemsServices;
using DataAccessLayer.Services.UserService;
using DataAccessLayer.Services.ProfileServices;
using System.Diagnostics.CodeAnalysis;

namespace DataAccessLayer
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

        public static void SetupRepositoryCollection(string[] args, WebApplicationBuilder builder, MongoDbSettings settings)
        {

        }
    }
}
