using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Persistence.EntityTypeConfigurations.Estates;

public class ResidentialEstateConfiguration : IEntityTypeConfiguration<ResidentialEstate>
{
    public void Configure(EntityTypeBuilder<ResidentialEstate> builder)
    {
        builder.HasBaseType<Estate>();
    }
}
