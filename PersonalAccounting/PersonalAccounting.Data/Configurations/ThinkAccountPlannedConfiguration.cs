using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalAccounting.Data.Core.Models;

namespace PersonalAccounting.Data.Configurations;

public class ThinkAccountPlannedConfiguration : IEntityTypeConfiguration<ThinkAccountPlanned>
{
    public void Configure(EntityTypeBuilder<ThinkAccountPlanned> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(100);

        builder.Property(p => p.ShortDescription)
            .HasMaxLength(500);

        builder.Property(p => p.Url)
            .HasColumnType("text");

        builder.HasOne(p => p.User)
            .WithMany(p => p.ThinkAccountPlanneds)
            .HasForeignKey(p => p.UserId);

        builder.HasMany(p => p.Tags)
            .WithOne(p => p.Think)
            .HasForeignKey(p => p.ThinkId);
    }
}