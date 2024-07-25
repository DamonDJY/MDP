using Ardalis.Result;
using Ardalis.SharedKernel;
using MDP.Domain.Entities;
using MediatR;

namespace MDP.Application.Queries;

public record GetOrderByIdQuery(int Id) : IQuery<Result<Order>>
{
}
