using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_CASE.Concretes;
using MVC_CASE.Contexts;
using MVC_CASE.Contracts;
using MVC_CASE.Enums;
using MVC_CASE.Models;
using MVC_CASE.UnitOfWorks;

namespace MVC_CASE
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // DbContext servisini ekleyip ve SQL Server kullan�yorum
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")));

            // Identity servisi ekleyip �ifre kurallar�n� belirliyorum
            builder.Services.AddIdentity<Kullanici, IdentityRole>(x => x.Password = new PasswordOptions()
            {
                RequireDigit = false,
                RequiredLength = 1,
                RequireLowercase = false,
                RequireUppercase = false,
                RequireNonAlphanumeric = false,
                RequiredUniqueChars = 0,
            }).AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders();

            // Repository katman� i�in dependency injection ayarlar�n� yap�yorum
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();

                // Kategorileri seed et
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category { Name = "SUV", Description = "SUV ara�lar" },
                        new Category { Name = "Sedan", Description = "Sedan ara�lar" },
                        new Category { Name = "Hatchback", Description = "Hatchback ara�lar" },
                        new Category { Name = "Elektrikli", Description = "Elektrikli ara�lar" }
                    );
                    context.SaveChanges();
                }

                // Admin kullan�c�y� seed et
                await MVC_CASE.Helpers.SeedData.SeedAdmin(services);
            }

            app.Run();
        }

       
    }
}
