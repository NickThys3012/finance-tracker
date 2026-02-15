using FinanceTracker.Domain.Base;

namespace FinanceTracker.Domain;

public class Category : BaseClass
{
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public void UpdateName(string newName)
    {
        Name = newName;
    }
}