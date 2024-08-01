using Ardalis.Result;
using Ardalis.SharedKernel;
using MDP.Domain.Entities;
using MDP.Domain.Interfaces;
using MediatR;

namespace MDP.Application.Queries;

public class GetOrderByIdQueryHandler(IOrderRepository _orderRepository) : IQueryHandler<GetOrderByIdQuery, Result<Order>>
{

  public async Task<Result<Order>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
  {
    return await _orderRepository.GetByIdAsync(request.Id);
  }
}
