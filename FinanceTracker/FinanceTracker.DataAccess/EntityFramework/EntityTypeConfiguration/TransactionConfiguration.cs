using FinanceTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.DataAccess.EntityFramework.EntityTypeConfiguration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Account).WithMany();
        builder.HasMany(x => x.Splits).WithOne();
        builder.HasOne(x => x.ImportBatch).WithMany().HasForeignKey(x => x.ImportBatchId);
    }
}