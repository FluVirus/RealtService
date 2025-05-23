﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Terms;
using RealtService.Domain.Entities.Users;

namespace RealtService.Persistence.EntityTypeConfigurations.Terms;

public class TermConfiguration : IEntityTypeConfiguration<Term>
{
    public void Configure(EntityTypeBuilder<Term> builder)
    {
        builder.HasKey(user => user.Id);
        builder.HasIndex(user => user.Id).IsUnique();

        builder.UseTpcMappingStrategy();

        builder.Property<int>(nameof(User.Id))
           .IsRequired()
           .ValueGeneratedOnAdd()
           .HasColumnType("int")
           .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
    }
}
