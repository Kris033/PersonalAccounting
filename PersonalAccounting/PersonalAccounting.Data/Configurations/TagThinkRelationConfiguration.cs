using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalAccounting.Data.Core.Models;

namespace PersonalAccounting.Data.Configurations;

public class TagThinkRelationConfiguration : IEntityTypeConfiguration<TagThinkRelation>
{
    public void Configure(EntityTypeBuilder<TagThinkRelation> builder)
    {
        builder.HasKey(p => new { p.TagId, p.ThinkId });

        builder.HasOne(p => p.Tag)
            .WithMany(p => p.Thinks)
            .HasForeignKey(p => p.TagId);

        builder.HasOne(p => p.Think)
            .WithMany(p => p.Tags)
            .HasForeignKey(p => p.ThinkId);
    }
}
