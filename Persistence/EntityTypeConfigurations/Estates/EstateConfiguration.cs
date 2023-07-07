using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Persistence.EntityTypeConfigurations.Estates;

public class EstateConfiguration : IEntityTypeConfiguration<Estate>
{
    public void Configure(EntityTypeBuilder<Estate> builder)
    {
        builder.HasKey(estate => estate.Id);
        builder.HasIndex(estate => estate.Id).IsUnique();

        builder.UseTpcMappingStrategy();

        builder.Property<int>(nameof(Estate.Id))
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasColumnType("int")
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        builder.Property<float>(nameof(Estate.Square))
            .IsRequired();
    }
}
