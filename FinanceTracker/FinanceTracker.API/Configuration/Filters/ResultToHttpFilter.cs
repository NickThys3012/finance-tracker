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
        if (context.Result is ObjectResult obj && obj.Value is IResult result)
            context.Result = result.Succeeded
                ? new OkObjectResult(obj.Value)
                : result.Messages.First().Reason switch
                {
                    FailureReason.NotFound => new NotFoundObjectResult(obj.Value),
                    FailureReason.NotValid => new BadRequestObjectResult(obj.Value),
                    _ => new ObjectResult(obj.Value) { StatusCode = StatusCodes.Status500InternalServerError }
                };

        await next();
    }
}