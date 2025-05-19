using Microsoft.AspNetCore.Identity;
using MVC_CASE.Enums;
using MVC_CASE.Models;

namespace MVC_CASE.Helpers
{
    public static class SeedData
    {
        public static async Task SeedAdmin(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<Kullanici>>();
            var user = await userManager.FindByEmailAsync("admin@example.com");

            if (user == null)
            {
                var newUser = new Kullanici
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    FullName = "Admin Kullanıcı",
                    Role = UserRole.Admin
                };

                var result = await userManager.CreateAsync(newUser, "Admin123!");
                if (result.Succeeded)
                {
                    Console.WriteLine("Admin kullanıcı başarıyla oluşturuldu.");
                }
                else
                {
                    foreach (var error in result.Errors)
                        Console.WriteLine($"Hata: {error.Description}");
                }
            }
        }
    }
}
