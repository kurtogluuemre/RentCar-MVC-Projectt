using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_CASE.Configs;
using MVC_CASE.Models;
using System.Reflection.Emit;

namespace MVC_CASE.Contexts
{
    /// <summary>
    /// Uygulamanın veritabanı bağlantısını ve DbSet tanımlarını içeren context sınıfıdır.
    /// IdentityDbContext sınıfından türetilmiştir ve Kullanici entity'siyle kimlik yönetimi sağlar.
    /// </summary>
    public class AppDbContext : IdentityDbContext<Kullanici>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Databesin Araba tablosu
        /// </summary>
        public DbSet<Car> Cars { get; set; }
        /// <summary>
        /// Databesin Category tablosu
        /// </summary>
        public DbSet<Category> Categories { get; set; }
        /// <summary>
        /// Databesin Kiralama tablosu
        /// </summary>
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Identity için gerekli

            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new RentalConfiguration());

            modelBuilder.Entity<Kullanici>()
            .Property(k => k.Role)
            .HasConversion<int>();

        }
    }
}
