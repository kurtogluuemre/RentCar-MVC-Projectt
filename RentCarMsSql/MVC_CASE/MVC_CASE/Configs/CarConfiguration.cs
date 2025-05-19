using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CASE.Models;

namespace MVC_CASE.Configs
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id); // Primary key

            builder.Property(c => c.Brand).IsRequired().HasMaxLength(50); // Marka zorunlu ve maks 50 karakter olmalı

            builder.Property(c => c.Price).HasColumnType("decimal(10,2)");

            builder.HasOne(c => c.Category) // ilişki bire çok
                .WithMany(cat => cat.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Cars");



        }
    }
}
