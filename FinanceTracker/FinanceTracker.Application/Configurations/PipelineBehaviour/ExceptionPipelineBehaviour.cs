using FinanceTracker.Contracts.BaseResponse;
using FinanceTracker.Enums;
using MediatR;

namespace FinanceTracker.Application.Configurations.PipelineBehaviour;

public sealed class ExceptionPipelineBehaviour<TRequest, TResult> : IPipelineBehavior<TRequest, TResult>
    where TRequest : IRequest<TResult> where TResult : Result, new()
{
    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next(cancellationToken);
        }
        catch (Exception e)
        {
            return new TResult
            {
                Succeeded = false,
                Messages = [new FailureMessage(e.Message, FailureReason.Error)]
            };
        }
    }
}