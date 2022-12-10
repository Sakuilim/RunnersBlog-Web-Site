using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;
using RunnersBlogMVC.Services.LoginServices;
using RunnersBlogMVC.Services.RoleServices;
using RunnersBlogMVC.Services;
using MongoDB.Driver;
using RunnersBlogMVC.Settings;

namespace RunnersBlogMVC
{
    public static class ServiceCollections
    {
        public static IServiceCollection SetupCollection(string[] args, WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();

            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IItemsRepository, MongoDbItemsRepo>();
            builder.Services.AddScoped<IBaseService<Item, ItemDto>, ItemsService>();
            builder.Services.AddScoped<IBaseService<User, User>, UserService>();
            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<IRoleService, RoleService>();

            return builder.Services;
        }

        public static IServiceCollection SetupRepositoryCollection(string[] args, WebApplicationBuilder builder, MongoDbSettings settings)
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

            return builder.Services;
        }
    }
}
