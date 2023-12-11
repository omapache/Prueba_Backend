
using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class ContactPersonConfiguration : IEntityTypeConfiguration<ContactPerson>
    {
        public void Configure(EntityTypeBuilder<ContactPerson> builder)
        {
            builder.ToTable("ContactPerson");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.Description).IsUnique();
            builder.Property(e => e.Description).IsRequired().HasMaxLength(60);

            builder.HasOne(e =>e.ContactType)
            .WithMany(e => e.ContactPeople)
            .HasForeignKey(e => e.ContactTypeId);

            builder.HasOne(e => e.Person)
            .WithMany(e => e.ContactPeople)
            .HasForeignKey(e => e.PersonId);
        }
    }
}