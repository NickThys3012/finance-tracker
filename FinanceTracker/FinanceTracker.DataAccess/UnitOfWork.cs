using FinanceTracker.Contracts.Interfaces;
using FinanceTracker.Contracts.Interfaces.Repositories;
using FinanceTracker.Contracts.Interfaces.Repositories.CsvProfileSub;
using FinanceTracker.DataAccess.EntityFramework;
using FinanceTracker.DataAccess.Repositories;
using FinanceTracker.DataAccess.Repositories.CsvProfileSub;

namespace FinanceTracker.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly FinanceTrackerDbContext _context;

    public UnitOfWork(FinanceTrackerDbContext context)
    {
        _context = context;
        Accounts = new AccountRepository(_context);
        Categories = new CategoryRepository(_context);
        CsvProfiles = new CsvProfileRepository(_context);
        ImportBatches = new ImportBatchRepository(_context);
        Receipts = new ReceiptRepository(_context);
        Transactions = new TransactionRepository(_context);
        TransactionSplits = new TransactionSplitRepository(_context);
        AmountParsingDefinitions = new AmountParsingDefinitionRepository(_context);
        ColumnMappingDefinitions = new ColumnMappingDefinitionRepository(_context);
        ColumnSelectors = new ColumnSelectorRepository(_context);
        CsvProfileDefinitions = new CsvProfileDefinitionRepository(_context);
        TextReplaceRules = new TextReplaceRuleRepository(_context);
    }

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

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}