using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Terms;

namespace RealtService.Persistence.EntityTypeConfigurations.Terms;

public class CommercialSaleConfiguration : IEntityTypeConfiguration<CommercialSale>
{
    public void Configure(EntityTypeBuilder<CommercialSale> builder)
    {
        builder.HasBaseType<CommercialTerm>();
        
        builder.Property<decimal>(nameof(CommercialSale.Price))
            .HasColumnType("money")
            .IsRequired();
    }
}
