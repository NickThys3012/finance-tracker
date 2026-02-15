using FinanceTracker.Domain.CsvProfileSub;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.DataAccess.EntityFramework.EntityTypeConfiguration.CsvProfileSub;

public class ColumnSelectorConfiguration : IEntityTypeConfiguration<ColumnSelector>
{
    public void Configure(EntityTypeBuilder<ColumnSelector> builder)
    {
        builder.HasKey(x => x.Id);
    }
}