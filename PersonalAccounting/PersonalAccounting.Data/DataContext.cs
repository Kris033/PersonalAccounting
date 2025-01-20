using Microsoft.EntityFrameworkCore;
using PersonalAccounting.Data.Configurations;
using PersonalAccounting.Data.Core.Models;

namespace PersonalAccounting.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<User> User { get; set; }

    public DbSet<UserBalance> UserBalance { get; set; }

    public DbSet<UserBalanceOperation> UserBalanceOperation { get; set; }

    public DbSet<ThinkAccountPlanned> ThinkAccountPlanned { get; set; }

    public DbSet<ThinkSample> ThinkSample { get; set; }

    public DbSet<Tag> Tag { get; set; }

    public DbSet<TagThinkRelation> TagThinkRelation { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserBalanceConfiguration());
        modelBuilder.ApplyConfiguration(new UserBalanceOperationConfiguration());
        modelBuilder.ApplyConfiguration(new ThinkSampleConfiguration());
        modelBuilder.ApplyConfiguration(new ThinkAccountPlannedConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new TagThinkRelationConfiguration());
    }
}