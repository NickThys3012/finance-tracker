using FinanceTracker.Domain.CsvProfileSub;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.DataAccess.EntityFramework.EntityTypeConfiguration.CsvProfileSub;

public class CsvProfileDefinitionConfiguration : IEntityTypeConfiguration<CsvProfileDefinition>
{
    public void Configure(EntityTypeBuilder<CsvProfileDefinition> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.AmountParsing);
        builder.HasOne(x => x.Mapping);
        builder.HasMany(x => x.DescriptionCleanupRules).WithOne();
    }
}