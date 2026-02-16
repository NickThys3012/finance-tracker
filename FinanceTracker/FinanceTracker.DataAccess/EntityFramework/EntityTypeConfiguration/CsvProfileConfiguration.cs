using FinanceTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.DataAccess.EntityFramework.EntityTypeConfiguration;

public class CsvProfileConfiguration : IEntityTypeConfiguration<CsvProfile>
{
    public void Configure(EntityTypeBuilder<CsvProfile> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Definition);
    }
}