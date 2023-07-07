using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Persistence.EntityTypeConfigurations.Estates;

public class CommercialEstateConfiguration: IEntityTypeConfiguration<CommercialEstate>
{
    public void Configure(EntityTypeBuilder<CommercialEstate> builder)
    {
        builder.HasBaseType<Estate>();
    }
}
