﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;
using RunnersBlogMVC.Services;
using RunnersBlogMVC.Services.LoginServices;
using RunnersBlogMVC.Services.RoleServices;
using RunnersBlogMVC.Settings;
using System.Diagnostics.CodeAnalysis;

namespace RunnersBlogMVC
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            ConfigurationManager configuration = builder.Configuration;

            builder.Services.AddControllersWithViews();

            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IItemsRepository, MongoDbItemsRepo>();
            builder.Services.AddScoped<IBaseService<Item, ItemDto>, ItemsService>();
            builder.Services.AddScoped<IBaseService<User, User>, UserService>();
            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<IRoleService, RoleService>();

            var settings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

            builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
            {
                return new MongoClient(settings.ConnectionString);
            });
            builder.Services
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>(
                settings.ConnectionString, "Users"
                );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}