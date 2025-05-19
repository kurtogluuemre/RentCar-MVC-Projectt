using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CASE.Models;

public class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.RentDate)
            .IsRequired();

        builder.Property(r => r.ReturnDate)
            .IsRequired();

        builder.Property(r => r.TotalPrice)
            .HasColumnType("decimal(10,2)");

        builder.HasOne(r => r.Car)
            .WithMany(c => c.Rentals)
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.Restrict); // Araba silinince kiralama verisi silinmesin

        builder.HasOne(r => r.Kullanici)
            .WithMany(k=>k.Kiralamalar) // Kullanıcının Rentals koleksiyonu yoksa boş bırakılır
            .HasForeignKey(r => r.KullaniciId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Rentals");
    }
}
