using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalAccounting.Data.Core.Models;

namespace PersonalAccounting.Data.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(50);

        builder.HasMany(p => p.Thinks)
            .WithOne(p => p.Tag)
            .HasForeignKey(p => p.TagId);

        builder.HasOne(p => p.User)
            .WithMany(p => p.TagsCreated)
            .HasForeignKey(p => p.UserId);
    }
}