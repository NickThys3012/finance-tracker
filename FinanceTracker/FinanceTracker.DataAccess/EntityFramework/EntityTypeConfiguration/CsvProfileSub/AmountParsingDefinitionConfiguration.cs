using FinanceTracker.Domain.CsvProfileSub;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.DataAccess.EntityFramework.EntityTypeConfiguration.CsvProfileSub;

public class AmountParsingDefinitionConfiguration : IEntityTypeConfiguration<AmountParsingDefinition>
{
    public void Configure(EntityTypeBuilder<AmountParsingDefinition> builder)
    {
        builder.HasKey(x => x.Id);
    }
}