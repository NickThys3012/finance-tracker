using FinanceTracker.Domain.Base;

namespace FinanceTracker.Domain;

public class TransactionSplit : BaseClassWithId
{
    private TransactionSplit()
    {
    }

    public TransactionSplit(int transactionId, Transaction transaction, int categoryId, Category category,
        decimal amount, string note)
    {
        TransactionId = transactionId;
        Transaction = transaction;
        CategoryId = categoryId;
        Category = category;
        Amount = amount;
        Note = note;
    }

    public int TransactionId { get; private set; }
    public Transaction Transaction { get; private set; }
    public int CategoryId { get; private set; }
    public Category Category { get; private set; }
    public decimal Amount { get; private set; }
    public string Note { get; private set; }
}