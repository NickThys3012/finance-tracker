using FinanceTracker.Domain.CsvProfileSub;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.DataAccess.EntityFramework.EntityTypeConfiguration.CsvProfileSub;

public class ColumnMappingDefinitionConfiguration : IEntityTypeConfiguration<ColumnMappingDefinition>
{
    public void Configure(EntityTypeBuilder<ColumnMappingDefinition> builder)
    {
        builder.HasKey(x => x.Id);

        // Required selectors (avoid cascade paths in SQL Server)
        builder.HasOne(x => x.Date)
            .WithMany()
            .HasForeignKey("DateId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Description)
            .WithMany()
            .HasForeignKey("DescriptionId")
            .OnDelete(DeleteBehavior.NoAction);

        // Optional selectors (also disable cascade to keep behavior consistent)
        builder.HasOne(x => x.Counterparty)
            .WithMany()
            .HasForeignKey("CounterpartyId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Reference)
            .WithMany()
            .HasForeignKey("ReferenceId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.ExternalId)
            .WithMany()
            .HasForeignKey("ExternalIdId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Currency)
            .WithMany()
            .HasForeignKey("CurrencyId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Account)
            .WithMany()
            .HasForeignKey("AccountId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Amount)
            .WithMany()
            .HasForeignKey("AmountId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Debit)
            .WithMany()
            .HasForeignKey("DebitId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Credit)
            .WithMany()
            .HasForeignKey("CreditId")
            .OnDelete(DeleteBehavior.NoAction);
    }
}