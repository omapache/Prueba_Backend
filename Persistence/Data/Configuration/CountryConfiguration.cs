using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
        }
    }
}