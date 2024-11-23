using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalAccounting.Data.Core.Models;

namespace PersonalAccounting.Data.Configurations;

public class ThinkSampleConfiguration : IEntityTypeConfiguration<ThinkSample>
{
    public void Configure(EntityTypeBuilder<ThinkSample> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(100);

        builder.Property(p => p.ShortDescription)
            .HasMaxLength(500);

        builder.HasOne(p => p.Author)
            .WithMany(p => p.ThinkSamples)
            .HasForeignKey(p => p.AuthorId);
    }
}