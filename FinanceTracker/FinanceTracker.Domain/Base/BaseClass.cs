namespace FinanceTracker.Domain.Base;

public abstract class BaseClass
{
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public int Id { get; protected set; }
}