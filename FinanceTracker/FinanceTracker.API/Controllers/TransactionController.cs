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
    private readonly IMediator _mediator = mediator;

    [HttpGet("{id:int}")]
    public async Task<Result<GetTransactionDto>> GetById([FromRoute] int id)
    {
        return await _mediator.Send(new GetTransactionRequest { Id = id });
    }
}