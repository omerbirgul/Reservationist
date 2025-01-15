using System.Net.Mail;
using App.Repository.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Repository.Database.EntityConfigurations;

public class SubscribeConfiguration : IEntityTypeConfiguration<Subscribe>
{
    public void Configure(EntityTypeBuilder<Subscribe> builder)
    {
        var mailAddressConverter = new ValueConverter<MailAddress, string>(
            subscribe => subscribe.Address, //MailAddress => string
            subscribe => new MailAddress(subscribe) // string => MailAddress
        );
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Mail).IsRequired().HasConversion(mailAddressConverter);
    }
}