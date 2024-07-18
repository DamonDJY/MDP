using Ardalis.Result;
using Ardalis.SharedKernel;
using MDP.Domain.Entities;
using MediatR;

namespace MDP.Application.Queries;

public record GetOrderByIdQuery(Guid Id) : IQuery<Result<Order>>
{
}
