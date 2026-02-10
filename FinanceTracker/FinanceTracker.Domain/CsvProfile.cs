using FinanceTracker.Domain.Base;
using FinanceTracker.Domain.CsvProfileSub;

namespace FinanceTracker.Domain;

public class CsvProfile : BaseClassWithId
{
    private CsvProfile()
    {
    }

    public CsvProfile(string name, string bankName, bool isActive, CsvProfileDefinition definition)
    {
        Name = name;
        BankName = bankName;
        IsActive = isActive;
        Definition = definition;
    }

    public string Name { get; private set; }

    // If you have multiple accounts/banks, this helps keep profiles scoped
    public string? BankName { get; private set; }

    public bool IsActive { get; private set; }

    // Store the actual profile definition as JSON for flexibility
    // (EF Core will map this to TEXT in SQLite)
    public required CsvProfileDefinition Definition { get; set; }
}