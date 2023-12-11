using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class ProgramationConfiguration : IEntityTypeConfiguration<Programation>
    {
        public void Configure(EntityTypeBuilder<Programation> builder)
        {
            builder.ToTable("Programation");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne(e => e.Employee)
            .WithMany(e => e.Programations)
            .HasForeignKey(e => e.EmployeeId);

            builder.HasOne(e => e.Contract)
            .WithMany(e => e.Programations)
            .HasForeignKey(e => e.ContractId);

            builder.HasOne(e => e.Shift)
            .WithMany(e => e.Programations)
            .HasForeignKey(e => e.ShiftId);
        }
    }
}