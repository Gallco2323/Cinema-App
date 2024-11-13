using CinemaApp.Data;
using Microsoft.EntityFrameworkCore;

using static CinemaApp.Web.Infrastructure.Extensions.ApplicationBuilderExtensions;
using CinemaApp.Services.Mapping;
using CinemaApp.Web.ViewModels;
public class Program
{
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

        string connectionString = builder.Configuration.GetConnectionString("SqlServer");

            // Add services to the container.
            builder.Services.AddDbContext<CinemaDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            builder.Services.AddControllersWithViews();

       
        
            var app = builder.Build();
          
        AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

        app.ApplyMigrations();

            app.Run();
        }
    }

