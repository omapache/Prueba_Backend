using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contract");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.ContractDate);
            builder.Property(e => e.ContractFinalDate);

            builder.HasOne(e => e.Client)
            .WithMany(e => e.Contracts)
            .HasForeignKey(e => e.ClientId);

            builder.HasOne(e => e.Employee)
            .WithMany(e => e.Contracts)
            .HasForeignKey(e => e.EmployeeId);

            builder.HasOne(e => e.Status)
            .WithMany(e => e.Contracts)
            .HasForeignKey(e => e.StatusId);
        }
    }
}