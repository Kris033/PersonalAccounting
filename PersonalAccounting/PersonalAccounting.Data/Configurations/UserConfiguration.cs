using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalAccounting.Data.Core.Models;

namespace PersonalAccounting.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(o => o.TelegramUserId);

        builder.HasOne(p => p.UserBalance)
            .WithOne(p => p.User)
            .HasForeignKey<UserBalance>(p => p.UserId);

        builder.HasMany(p => p.ThinkAccountPlanneds)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        builder.HasMany(p => p.ThinkSamples)
            .WithOne(p => p.Author)
            .HasForeignKey(p => p.AuthorId);

        builder.HasMany(p => p.TagsCreated)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
    }
}
