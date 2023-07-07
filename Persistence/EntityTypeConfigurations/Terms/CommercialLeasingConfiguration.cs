using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Terms;

namespace RealtService.Persistence.EntityTypeConfigurations.Terms;

public class CommercialLeasingConfiguration : IEntityTypeConfiguration<CommercialLeasing>
{
    public void Configure(EntityTypeBuilder<CommercialLeasing> builder)
    {
        builder.HasBaseType<CommercialTerm>();

        builder.Property<decimal?>(nameof(CommercialLeasing.PricePerMonth))
            .HasColumnType("money")
            .HasDefaultValue(null)
            .IsRequired(false);

        builder.Property<decimal?>(nameof(CommercialLeasing.PricePerYear))
            .HasColumnType("money")
            .HasDefaultValue(null)
            .IsRequired(false);

        builder.Property<bool>(nameof(CommercialLeasing.AllowedManufacturing))
            .HasColumnType("tinyint")
            .HasConversion<int>()
            .IsRequired();

        builder.Property<bool>(nameof(CommercialLeasing.AllowedScheduling))
            .HasColumnType("tinyint")
            .HasConversion<int>()
            .IsRequired();
    }
}
