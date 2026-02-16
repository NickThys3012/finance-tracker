using FinanceTracker.Domain.CsvProfileSub;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.DataAccess.EntityFramework.EntityTypeConfiguration.CsvProfileSub;

public class TextReplaceRuleConfiguration : IEntityTypeConfiguration<TextReplaceRule>
{
    public void Configure(EntityTypeBuilder<TextReplaceRule> builder)
    {
        builder.HasKey(x => x.Id);
    }
}