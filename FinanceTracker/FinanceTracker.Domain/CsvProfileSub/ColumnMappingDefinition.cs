using FinanceTracker.Enums.CvsProfile;

namespace FinanceTracker.Domain.CsvProfileSub;

public class ColumnMappingDefinition
{
    public ColumnMappingDefinition(MappingStrategy strategy, ColumnSelector date, ColumnSelector description,
        ColumnSelector? counterparty, ColumnSelector? reference, ColumnSelector? externalId, ColumnSelector? currency,
        ColumnSelector? account, ColumnSelector? amount, ColumnSelector? debit, ColumnSelector? credit)
    {
        Strategy = strategy;
        Date = date;
        Description = description;
        Counterparty = counterparty;
        Reference = reference;
        ExternalId = externalId;
        Currency = currency;
        Account = account;
        Amount = amount;
        Debit = debit;
        Credit = credit;
    }

    // Support mapping by column name (header-based) OR by index (no header / unstable headers)
    public MappingStrategy Strategy { get; set; } = MappingStrategy.ByColumnName;

    // Canonical fields you want to import
    public ColumnSelector Date { get; set; }

    public ColumnSelector Description { get; set; }
    public ColumnSelector? Counterparty { get; set; }
    public ColumnSelector? Reference { get; set; }
    public ColumnSelector? ExternalId { get; set; }
    public ColumnSelector? Currency { get; set; }
    public ColumnSelector? Account { get; set; }

    // Amount: either single column OR debit+credit columns
    public ColumnSelector? Amount { get; set; }
    public ColumnSelector? Debit { get; set; }
    public ColumnSelector? Credit { get; set; }
}