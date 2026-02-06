using FinanceTracker.Contracts.BaseResponse;
using FinanceTracker.Contracts.Models.Transactions.GetTransaction;
using FinanceTracker.Domain;
using MediatR;

namespace FinanceTracker.Application.Transactions;

public class GetTransactionRequest : IRequest<Result<GetTransactionDto>>
{
    public int Id { get; set; }
}

public class GetTransactionRequestHandler : IRequestHandler<GetTransactionRequest, Result<GetTransactionDto>>
{
    public Task<Result<GetTransactionDto>> Handle(GetTransactionRequest request,
        CancellationToken cancellationToken)
    {
        var transaction = Transaction.Create(23);
        return Task.FromResult(Result<GetTransactionDto>.Success(new GetTransactionDto(transaction)));
    }
}