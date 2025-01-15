using App.Repository.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repository.Database.EntityConfigurations;

public class HotelServiceConfiguration : IEntityTypeConfiguration<HotelService>
{
    public void Configure(EntityTypeBuilder<HotelService> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(20);
        builder.Property(x => x.ServiceIcon).IsRequired();

    }
}