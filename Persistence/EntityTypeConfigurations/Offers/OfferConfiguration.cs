using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Users;

namespace RealtService.Persistence.EntityTypeConfigurations.Offers;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.HasKey(offer => offer.Id);
        builder.HasIndex(offer => offer.Id).IsUnique();

        builder.UseTphMappingStrategy();

        builder.HasOne<User>(offer => offer.User)
            .WithMany(user => user.Offers)
            .HasForeignKey(offer => offer.UserId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.Property<string>(nameof(Offer.Name))
            .HasMaxLength(255)
            .IsRequired();

        builder.Property<string>(nameof(Offer.Address))
            .HasMaxLength(255)
            .IsRequired();

        builder.Property<int>(nameof(Offer.Id))
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasColumnType("int")
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        builder.Property<DateTime>(nameof(Offer.PublicationDate))
            .IsRequired();

        builder.Property<DateTime?>(nameof(Offer.EditDate))
            .IsRequired(false);

        builder.Property<string?>(nameof(Offer.Description))
            .IsRequired(false);
    }
}
