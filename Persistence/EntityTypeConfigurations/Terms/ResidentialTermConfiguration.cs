using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Terms;

namespace RealtService.Persistence.EntityTypeConfigurations.Terms;

public class ResidentialTermConfiguration : IEntityTypeConfiguration<ResidentialTerm>
{
    public void Configure(EntityTypeBuilder<ResidentialTerm> builder)
    {
        builder.HasBaseType<Term>();
    }
}
