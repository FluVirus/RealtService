using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Users;

namespace RealtService.Persistence.EntityTypeConfigurations.Users;

public class AgencyConfiguration : IEntityTypeConfiguration<Agency>
{
    public void Configure(EntityTypeBuilder<Agency> builder)
    {
        builder.HasBaseType<User>();

        builder.Property(agency => agency.AgencyUniqueNumber)
            .IsRequired(false);
    }
}
