using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalAccounting.Data.Core.Models;

namespace PersonalAccounting.Data.Configurations;

public class TelegramUserSessionConfiguration : IEntityTypeConfiguration<TelegramUserSession>
{
    public void Configure(EntityTypeBuilder<TelegramUserSession> builder)
    {
        builder.HasKey(p => p.SessionId);

        builder.HasIndex(p => p.TelegramId)
            .IsUnique();

        builder.HasOne(p => p.User)
            .WithMany(p => p.TelegramUserSessions)
            .HasForeignKey(p => p.UserId);
    }
}