using FinanceTracker.Domain.Base;

namespace FinanceTracker.Domain;

public class Account : BaseClassWithId
{
    private Account()
    {
    }

    public Account(string accountNr, string accountName)
    {
        AccountNr = accountNr;
        AccountName = accountName;
    }

    public string AccountNr { get; private set; }
    public string AccountName { get; private set; }

    //Maybe add a default category
    public void UpdateName(string newName)
    {
        AccountName = newName;
    }

    public void UpdateNr(string newNr)
    {
        AccountNr = newNr;
    }
}