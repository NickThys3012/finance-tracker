using FinanceTracker.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using IResult = FinanceTracker.Contracts.Result.IResult;

namespace FinanceTracker.API.Configuration.Filters;

public class ResultToHttpFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        // If the action already produced an IActionResult, don't touch it.
        // (This filter only transforms plain object results.)
        if (context.Result is ObjectResult obj
            && context.Result.GetType() == typeof(ObjectResult)
            && obj.Value is IResult result)
        {
            if (result.Succeeded)
            {
                context.Result = new OkObjectResult(obj.Value);
            }
            else if (!result.Messages.Any())
            {
                // No failure messages provided; fall back to a generic 500 error.
                context.Result = new ObjectResult(obj.Value)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
            else
            {
                // Derive status code from all failure reasons with explicit precedence
                var reasons = result.Messages.Select(m => m.Reason).ToList();

                // Precedence: NotFound > NotValid > default 500
                var effectiveReason =
                    reasons.Contains(FailureReason.NotFound) ? FailureReason.NotFound :
                    reasons.Contains(FailureReason.NotValid) ? FailureReason.NotValid :
                    (FailureReason?)null;

                context.Result = effectiveReason switch
                {
                    FailureReason.NotFound => new NotFoundObjectResult(obj.Value),
                    FailureReason.NotValid => new BadRequestObjectResult(obj.Value),
                    _ => new ObjectResult(obj.Value) { StatusCode = StatusCodes.Status500InternalServerError }
                };
            }
        }

        await next();
    }
}