using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CASE.Models;

namespace MVC_CASE.Configs
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id); // Primary key

            builder.Property(c => c.Name).IsRequired().HasMaxLength(50); // İsim gerekli ve maks 50 karakter 

            builder.Property(c => c.Description).HasMaxLength(250); // Açıklama zorunlu değil ama maks 250 karakter.

            builder.ToTable("Categories");
        }
    }
}
