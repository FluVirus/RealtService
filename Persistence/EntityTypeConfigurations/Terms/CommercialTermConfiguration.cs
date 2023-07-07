using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Terms;

namespace RealtService.Persistence.EntityTypeConfigurations.Terms;

public class CommercialTermConfiguration : IEntityTypeConfiguration<CommercialTerm>
{
    public void Configure(EntityTypeBuilder<CommercialTerm> builder)
    {
        builder.HasBaseType<Term>();
    }
}
