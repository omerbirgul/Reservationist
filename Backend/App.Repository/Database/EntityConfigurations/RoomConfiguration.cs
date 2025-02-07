using App.Repository.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repository.Database.EntityConfigurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(150);
        builder.Property(x => x.BedCount).IsRequired();
        builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(x => x.Title).IsRequired().HasMaxLength(30);
        builder.Property(x => x.BathCount).IsRequired();
        builder.Property(x => x.CoverImage).IsRequired();
        builder.Property(x => x.HasWifi).IsRequired();
        builder.Property(x => x.RoomNumber).HasMaxLength(4).IsRequired();
    }
}