using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalAccounting.Data.Core.Models;

namespace PersonalAccounting.Data.Configurations;

public class UserBalanceOperationConfiguration : IEntityTypeConfiguration<UserBalanceOperation>
{
    public void Configure(EntityTypeBuilder<UserBalanceOperation> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.ReasonChange)
            .HasMaxLength(500);

        builder.HasOne(p => p.UserBalance)
            .WithMany(p => p.Operations)
            .HasForeignKey(p => p.BalanceUserId);
    }
}
