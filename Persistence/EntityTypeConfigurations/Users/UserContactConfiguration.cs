using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Users;

namespace RealtService.Persistence.EntityTypeConfigurations.Users;

public class UserContactConfiguration : IEntityTypeConfiguration<UserContact>
{
    public void Configure(EntityTypeBuilder<UserContact> builder)
    {
        builder.HasKey(contact => contact.Id);

        builder.Property(contact => contact.Id)
              .ValueGeneratedOnAdd()
              .HasColumnType("int")
              .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        builder.Property(contact => contact.Name)
            .HasMaxLength(256)
            .IsRequired();

        //Relations defined in UserConfiguration
    }
}
