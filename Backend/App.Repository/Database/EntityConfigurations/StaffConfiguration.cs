using App.Repository.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repository.Database.EntityConfigurations;

public class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Image).IsRequired();
        builder.Property(x => x.FullName).IsRequired();
        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.InstagramUri).IsRequired();
        builder.Property(x => x.TwitterUri).IsRequired();
        builder.Property(x => x.FaceBookUri).IsRequired();
    }
}