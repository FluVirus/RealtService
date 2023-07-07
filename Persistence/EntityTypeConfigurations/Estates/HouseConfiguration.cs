using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Persistence.EntityTypeConfigurations.Estates;

public class HouseConfiguration : IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder.HasBaseType<ResidentialEstate>();

        builder.Property<int>(nameof(House.StroreyNumber))
            .IsRequired();

        builder.Property<int>(nameof(House.RoomNumber))
            .IsRequired();

        builder.Property<bool>(nameof(House.HasGarage))
            .HasColumnType("tinyint")
            .HasConversion<int>()
            .IsRequired();

        builder.Property<bool>(nameof(House.HasSwimmingPool))
            .HasColumnType("tinyint")
            .HasConversion<int>()
            .IsRequired();
    }
}
