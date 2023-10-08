﻿using Jazani.Domain.Mc.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructure.Mc.Configurations;
public class InvestmentconceptConfiguration : IEntityTypeConfiguration<Investmentconcept>
{
    public void Configure(EntityTypeBuilder<Investmentconcept> builder)
    {
        builder.ToTable("investmentconcept", "mc");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).HasColumnName("name");
        builder.Property(t => t.Description).HasColumnName("description");
        builder.Property(t => t.RegistrationDate)
            .HasColumnName("registrationdate")
            .HasConversion(new DateTimeToDateTimeOffset());
        builder.Property(t => t.State).HasColumnName("state");
    }
}
