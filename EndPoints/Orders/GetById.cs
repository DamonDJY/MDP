using Ardalis.Result;
using FastEndpoints;
using MDP.Application.Queries;
using MediatR;

namespace MDP.EndPoints.Orders;

public class GetById(IMediator _mediator) : Endpoint<Request, Response>
{
  public override void Configure()
  {
    Get(Request.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(Request request,
    CancellationToken cancellationToken)
  {
    var command = new GetOrderByIdQuery(request.Id);
    var result = await _mediator.Send(command, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }
    if (result.IsSuccess)
    {
      //automapper to do
      Response = new Response
      {
        Id = result.Value.Id,
        CustomerName = result.Value.CustomerName,
        ShoppingAddress = result.Value.ShoppingAddress,
        Phone = result.Value.Phone,
        Email = result.Value.Email,
        Status = result.Value.Status,
        CreatedAt = result.Value.CreatedAt,
        UpdatedAt = result.Value.UpdatedAt,
        Items = result.Value.Items
      };
    }
  }
}
