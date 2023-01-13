using DataAccessLayer.Settings;
using System.Diagnostics.CodeAnalysis;

namespace DataAccessLayer
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigurationManager configuration = builder.Configuration;

            ServiceCollections.SetupCollection(builder);

            var settings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

            ServiceCollections.SetupRepositoryCollection(args, builder, settings);

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

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}