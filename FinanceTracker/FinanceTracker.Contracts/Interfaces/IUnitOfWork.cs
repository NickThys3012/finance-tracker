using FinanceTracker.Contracts.Interfaces.Repositories;
using FinanceTracker.Contracts.Interfaces.Repositories.CsvProfileSub;

namespace FinanceTracker.Contracts.Interfaces;

public interface IUnitOfWork
{
    public IAccountRepository Accounts { get; }
    public ICategoryRepository Categories { get; }
    public ICsvProfileRepository CsvProfiles { get; }
    public IImportBatchRepository ImportBatches { get; }
    public IReceiptRepository Receipts { get; }
    public ITransactionRepository Transactions { get; }
    public ITransactionSplitRepository TransactionSplits { get; }

    public IAmountParsingDefinitionRepository AmountParsingDefinitions { get; }
    public IColumnMappingDefinitionRepository ColumnMappingDefinitions { get; }
    public IColumnSelectorRepository ColumnSelectors { get; }
    public ICsvProfileDefinitionRepository CsvProfileDefinitions { get; }
    public ITextReplaceRuleRepository TextReplaceRules { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}