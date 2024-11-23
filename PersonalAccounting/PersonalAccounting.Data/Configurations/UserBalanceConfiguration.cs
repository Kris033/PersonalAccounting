using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalAccounting.Data.Core.Models;

namespace PersonalAccounting.Data.Configurations;

public class UserBalanceConfiguration : IEntityTypeConfiguration<UserBalance>
{
    public void Configure(EntityTypeBuilder<UserBalance> builder)
    {
        builder.HasKey(p => p.UserId);

        builder.HasOne(p => p.User)
            .WithOne(p => p.UserBalance)
            .HasForeignKey<UserBalance>(p => p.UserId);

        builder.HasMany(p => p.Operations)
            .WithOne(p => p.UserBalance)
            .HasForeignKey(p => p.BalanceUserId);
    }
}
