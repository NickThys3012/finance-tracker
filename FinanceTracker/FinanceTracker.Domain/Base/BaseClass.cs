namespace FinanceTracker.Domain.Base;

public abstract class BaseClass
{
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}

public abstract class BaseClassWithId : BaseClass
{
    public int Id { get; protected set; }
}