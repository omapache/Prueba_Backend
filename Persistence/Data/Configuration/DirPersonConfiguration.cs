using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class DirPersonConfiguration : IEntityTypeConfiguration<DirPerson>
    {
        public void Configure(EntityTypeBuilder<DirPerson> builder)
        {
            builder.ToTable("DirPerson");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.TypeOfStreet)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.FirstNumber)
            .IsRequired();

            builder.Property(p => p.Letter)
            .HasMaxLength(1);

            builder.Property(p => p.Bis)
            .HasMaxLength(3);

            builder.Property(p => p.SecondLetter)
            .HasMaxLength(2);

            builder.Property(p => p.Cardinal)
            .HasMaxLength(10);

            builder.Property(p => p.SecondNumber)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.ThirdLetter)
            .HasMaxLength(10);

            builder.Property(p => p.ThirdNumber)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.SecondCardinal)
            .HasMaxLength(10);

            builder.Property(p => p.Complement)
            .HasMaxLength(50);

            builder.HasOne(a => a.Person)
            .WithOne(b => b.DirPerson)
            .HasForeignKey<DirPerson>(b => b.PersonId);

            builder.HasOne(p => p.City)
            .WithMany(p => p.DirPeople)
            .HasForeignKey(p => p.IdCity);
        }
    }
}