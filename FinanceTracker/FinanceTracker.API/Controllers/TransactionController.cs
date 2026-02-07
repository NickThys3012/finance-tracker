using FinanceTracker.Application.Transactions;
using FinanceTracker.Contracts.BaseResponse;
using FinanceTracker.Contracts.Models.Transactions.GetTransaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<Result<GetTransactionDto>> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetTransactionRequest { Id = id }, cancellationToken);
    }
}