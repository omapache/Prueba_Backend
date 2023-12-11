using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.IdPerson).IsUnique();

            builder.Property(e => e.RegisterDate);
            builder.HasOne(e => e.PersonType)
            .WithMany(e => e.People)
            .HasForeignKey(e => e.PersonTypeId);
        }
    }
}