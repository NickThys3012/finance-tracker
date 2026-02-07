using FinanceTracker.Enums;

namespace FinanceTracker.Contracts.BaseResponse;

public class FailureMessage(string message, FailureReason reason)
{
    public string Message { get; init; } = message;
    public FailureReason Reason { get; init; } = reason;
}