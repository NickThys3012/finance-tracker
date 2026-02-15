using System.Reflection;
using FinanceTracker.Domain;
using FinanceTracker.Domain.Base;
using FinanceTracker.Domain.CsvProfileSub;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.DataAccess.EntityFramework;

public class FinanceTrackerDbContext : DbContext
{
    public FinanceTrackerDbContext(DbContextOptions<FinanceTrackerDbContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CsvProfile> CsvProfiles { get; set; }
    public DbSet<ImportBatch> ImportBatches { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionSplit> TransactionSplits { get; set; }
    public DbSet<TransactionReceipt> TransactionReceipts { get; set; }
    public DbSet<AmountParsingDefinition> AmountParsingDefinitions { get; set; }
    public DbSet<ColumnMappingDefinition> ColumnMappingDefinitions { get; set; }
    public DbSet<ColumnSelector> ColumnSelectors { get; set; }
    public DbSet<CsvProfileDefinition> CsvProfileDefinitions { get; set; }
    public DbSet<TextReplaceRule> TextReplaceRules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var modifiedOrAdded = ChangeTracker.Entries<BaseClass>()
            .Where(e => e.State is EntityState.Added or EntityState.Modified);

        foreach (var entry in modifiedOrAdded)
        {
            if (entry.State == EntityState.Added) entry.Entity.CreatedTime = DateTime.Now;
            entry.Entity.UpdatedTime = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        var modifiedOrAdded = ChangeTracker.Entries<BaseClass>()
            .Where(e => e.State is EntityState.Added or EntityState.Modified);

        foreach (var entry in modifiedOrAdded)
        {
            if (entry.State == EntityState.Added) entry.Entity.CreatedTime = DateTime.Now;
            entry.Entity.UpdatedTime = DateTime.Now;
        }

        return base.SaveChanges();
    }
}