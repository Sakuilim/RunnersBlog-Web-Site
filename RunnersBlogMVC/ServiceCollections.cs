using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;
using RunnersBlogMVC.Services.LoginServices;
using RunnersBlogMVC.Services.RoleServices;
using MongoDB.Driver;
using RunnersBlogMVC.Settings;
using RunnersBlogMVC.Services.ItemsServices;
using RunnersBlogMVC.Services.UserService;
using RunnersBlogMVC.Common;
using RunnersBlogMVC.Services.ProfileServices;

namespace RunnersBlogMVC
{
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

            builder.Services.AddSingleton<IItemsRepository, MongoDbItemsRepo>();
            builder.Services.AddScoped<IItemsService, ItemsService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IOrderHelper, OrderHelper>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Home/AccessDenied");
            });

            builder.Services.AddHttpContextAccessor();
        }

        public static void SetupRepositoryCollection(string[] args, WebApplicationBuilder builder, MongoDbSettings settings)
        {
            builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
            {
                return new MongoClient(settings.ConnectionString);
            });
            builder.Services
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>(
                settings.ConnectionString, "Users"
                );
        }
    }
}
