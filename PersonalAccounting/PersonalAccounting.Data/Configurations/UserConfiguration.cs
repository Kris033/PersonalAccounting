using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalAccounting.Data.Core.Models;

namespace PersonalAccounting.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(p => p.FirstName)
            .HasMaxLength(50);

        builder.Property(p => p.LastName)
            .HasMaxLength(50);

        builder.Property(p => p.MiddleName)
            .HasMaxLength(50);

        builder.Property(p => p.UserName)
            .HasMaxLength(50);

        builder.Property(p => p.PasswordHash)
            .HasMaxLength(64);

        builder.Property(p => p.Email)
            .HasMaxLength(311);

        builder.Property(p => p.Token)
            .HasColumnType("text");

        builder.HasOne(p => p.UserBalance)
            .WithOne(p => p.User)
            .HasForeignKey<UserBalance>(p => p.UserId);

        builder.HasMany(p => p.ThinkAccountPlanneds)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        builder.HasMany(p => p.TelegramUserSessions)
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
