using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace MDP.EndPoints.Orders;

public class Request
{
  public const string Route = "/orders/{Id}";

  public static string BindRoute(Guid id) => Route.Replace("{Id}", id.ToString());

  public Guid Id { get; set; }
}
