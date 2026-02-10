using FinanceTracker.Domain.Base;

namespace FinanceTracker.Domain;

public class Transaction : BaseClassWithId
{
    private readonly List<TransactionSplit> _splits = new();

    private Transaction()
    {
        // EF Core requires a parameterless constructor
    }

    public Transaction(DateTimeOffset date, string description, decimal amount, string currency, int accountId,
        int importBatchId)
    {
        ValidateTransactionInputs(description, amount, currency);

        Date = date;
        Description = description;
        Amount = amount;
        Currency = currency;
        AccountId = accountId;
        ImportBatchId = importBatchId;
    }

    public Transaction(DateTimeOffset date, string description, decimal amount, string currency, Account account,
        ImportBatch importBatch)
    {
        ValidateTransactionInputs(description, amount, currency);

        Date = date;
        Description = description;
        Amount = amount;
        Currency = currency;
        Account = account;
        ImportBatch = importBatch;
    }

    public DateTimeOffset Date { get; private set; }
    public string Description { get; private set; } = null!;
    public decimal Amount { get; private set; }
    public string Currency { get; private set; } = null!;
    public int AccountId { get; private set; }
    public Account Account { get; private set; } = null!;
    public int ImportBatchId { get; private set; }
    public ImportBatch ImportBatch { get; private set; } = null!;
    public IReadOnlyCollection<TransactionSplit> Splits => _splits;

    private static void ValidateTransactionInputs(string description, decimal amount, string currency)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required.", nameof(description));

        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency is required.", nameof(currency));

        // Consider whether 0 is allowed in your domain
        if (amount == 0m)
            throw new ArgumentException("Amount cannot be zero.", nameof(amount));
    }

    public void UpdateDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required.", nameof(description));

        Description = description.Trim();
    }

    public void ChangeAmount(decimal amount)
    {
        if (amount == 0m)
            throw new ArgumentException("Amount cannot be zero.", nameof(amount));
        Amount = amount;
    }

    public void AddSplit(TransactionSplit split)
    {
        if (split is null) throw new ArgumentNullException(nameof(split));

        _splits.Add(split);
    }
}