using FinanceTracker.Enums;

namespace FinanceTracker.Contracts.BaseResponse;

public class FailureMessage(string message, FailureReason reason)
{
    public string Message { get; set; } = message;
    public FailureReason Reason { get; set; } = reason;
}