using Ardalis.Result;
using Ardalis.SharedKernel;
using MDP.Domain.Entities;
using MDP.Domain.Interfaces;
using MediatR;

namespace MDP.Application.Commands;

public class CreateorderCommandHandler : ICommandHandler<CreateOrderCommand, Result<int>>
{
  private readonly IOrderRepository _orderRepository;

  public CreateorderCommandHandler(IOrderRepository orderRepository)
  {
    _orderRepository = orderRepository;
  }

  public async Task<Result<int>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
  {
    var order = new Order
    {
      CustomerName = request.CustomerName,
      OrderDate = request.OrderDate,
      IsCancelled = false,
      CreatedAt = DateTime.UtcNow,
      ShoppingAddress = request.ShippingAddress,
      DeliverAddress = request.DeliveryAddress,
      Phone = request.Phone,
      Email = request.Email

    };
    await _orderRepository.AddAsync(order);
    return order.Id;
  }
}
