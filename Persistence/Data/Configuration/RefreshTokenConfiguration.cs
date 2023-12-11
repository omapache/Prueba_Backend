using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshToken");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(e => e.UserId, "IX_RefreshToken_UserId");

            builder.Property(e => e.Created).HasMaxLength(6);
            builder.Property(e => e.Expires).HasMaxLength(6);
            builder.Property(e => e.UserId);
            builder.Property(e => e.Revoked).HasMaxLength(6);
            builder.Property(e => e.Token).HasMaxLength(50);

            builder.HasOne(d => d.User)
                .WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId);
        }
    }
}