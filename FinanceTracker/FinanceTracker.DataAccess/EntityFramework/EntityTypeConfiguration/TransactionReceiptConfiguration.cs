using FinanceTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.DataAccess.EntityFramework.EntityTypeConfiguration;

public class TransactionReceiptConfiguration : IEntityTypeConfiguration<TransactionReceipt>
{
    public void Configure(EntityTypeBuilder<TransactionReceipt> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Transaction)
            .WithOne()
            .HasForeignKey<TransactionReceipt>(x => x.TransactionId);

        builder.HasOne(x => x.Receipt)
            .WithOne()
            .HasForeignKey<TransactionReceipt>(x => x.ReceiptId);
    }
}