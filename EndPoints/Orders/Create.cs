using Ardalis.Result;
using FastEndpoints;
using MDP.Application.Commands;
using MDP.Infrastructure.Utility;
using MediatR;

namespace MDP.EndPoints.Orders;

public class Create(IMediator mediator) : Endpoint<CreateRequest, CreateResponse>
{
  public override void Configure()
  {
    Post("/orders");
    AllowAnonymous();
  }
  public override async Task HandleAsync(CreateRequest request, CancellationToken cancellationToken)
  {
    System.Console.WriteLine("Create order:", JsonHelper.Serialize(request));
    var command = new CreateOrderCommand
    {
      CustomerName = request.CustomerName,
      OrderDate = request.OrderDate,
      ShippingAddress = request.ShippingAddress,
      DeliveryAddress = request.DeliveryAddress,
      Phone = request.Phone,
      Email = request.Email
    };
    var result = await mediator.Send(command, cancellationToken);
    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }
    if (result.IsSuccess)
    {
      Response = new CreateResponse
      {
        Id = result.Value
      };
    }
  }
}
