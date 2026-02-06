using FinanceTracker.Domain.Base;

namespace FinanceTracker.Domain;

public class Transaction : BaseClass
{
    public int Id { get; private set; }
    public double Amount { get; private set; }

    public static Transaction Create(double amount)
    {
        return new Transaction
        {
            Id = Random.Shared.Next(99999),
            Amount = amount
        };
    }
}