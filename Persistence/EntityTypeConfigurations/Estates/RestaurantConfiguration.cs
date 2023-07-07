using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Persistence.EntityTypeConfigurations.Estates;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.HasBaseType<CommercialEstate>();

        builder.Property<int>(nameof(Restaurant.MaxGuestNumber))
            .IsRequired();
    }
}
