using FinanceTracker.Domain;

namespace FinanceTracker.Contracts.Models.Transactions.GetTransaction;

public class GetTransactionDto(Transaction transaction)
{
    public int Id { get; init; } = transaction.Id;
    public decimal Amount { get; init; } = transaction.Amount;
}