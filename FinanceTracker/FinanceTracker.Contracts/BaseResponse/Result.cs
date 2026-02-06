using FinanceTracker.Contracts.Result;
using FinanceTracker.Enums;

namespace FinanceTracker.Contracts.BaseResponse;

public class Result : IResult
{
    public bool Succeeded { get; set; }
    public List<FailureMessage> Messages { get; set; } = new();

    public static Result Failed()
    {
        return new Result { Succeeded = false };
    }

    public static Result NotFound(string className)
    {
        return new Result
        {
            Succeeded = false,
            Messages = [new FailureMessage($"{className} not found", FailureReason.NotFound)]
        };
    }

    public static Result Success()
    {
        return new Result { Succeeded = true };
    }

    public static Result NotFound(string className, Guid id)
    {
        return new Result
        {
            Succeeded = false,
            Messages = [new FailureMessage($"{className} not found with id: {id}", FailureReason.NotFound)]
        };
    }

    public static Result NotValid(IEnumerable<FailureMessage> messages)
    {
        return new Result { Succeeded = false, Messages = messages.ToList() };
    }
}

public sealed class Result<T> : Result, IResult<T>
{
    public T? Data { get; set; }

    public static Result<T> Success(T data)
    {
        return new Result<T> { Succeeded = true, Data = data };
    }

    public new static Result<T> Failed()
    {
        return new Result<T> { Succeeded = false };
    }

    public static Result<T> Failed(string message)
    {
        return new Result<T> { Succeeded = false, Messages = [new FailureMessage(message, FailureReason.Error)] };
    }

    public new static Result<T> NotFound(string className)
    {
        return new Result<T>
        {
            Succeeded = false,
            Messages = [new FailureMessage($"{className} not found", FailureReason.NotFound)]
        };
    }

    public new static Result<T> NotFound(string className, int id)
    {
        return new Result<T>
        {
            Succeeded = false,
            Messages = [new FailureMessage($"{className} not found with id: {id}", FailureReason.NotFound)]
        };
    }

    public new static Result<T> NotValid(IEnumerable<FailureMessage> messages)
    {
        return new Result<T> { Succeeded = false, Messages = messages.ToList() };
    }
}