using FinanceTracker.Contracts.BaseResponse;
using FinanceTracker.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceTracker.Application.Configurations.PipelineBehaviour;

public sealed class ExceptionPipelineBehaviour<TRequest, TResult> : IPipelineBehavior<TRequest, TResult>
    where TRequest : IRequest<TResult> where TResult : Result, new()
{
    private readonly ILogger<ExceptionPipelineBehaviour<TRequest, TResult>> _logger;

    public ExceptionPipelineBehaviour(ILogger<ExceptionPipelineBehaviour<TRequest, TResult>> logger)
    {
        _logger = logger;
    }

    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next(cancellationToken);
        }
        catch (Exception e)
        {
            var errorId = Guid.CreateVersion7().ToString();
            _logger.LogError(e, errorId);
            return new TResult
            {
                Succeeded = false,
                Messages = [new FailureMessage(errorId, FailureReason.UnexpectedError)]
            };
        }
    }
}