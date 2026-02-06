using FinanceTracker.Contracts.BaseResponse;

namespace FinanceTracker.Contracts.Result;

public interface IResult
{
    public bool Succeeded { get; set; }
    public List<FailureMessage> Messages { get; set; }
}

public interface IResult<out T> : IResult
{
    T? Data { get; }
}