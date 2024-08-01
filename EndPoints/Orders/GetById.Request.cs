using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace MDP.EndPoints.Orders;

public class Request
{
  public const string Route = "/orders/{Id:int}";

  public static string BindRoute(int id) => Route.Replace("{Id:int}", id.ToString());

  [FromRoute(Name = "Id")]
  public int Id { get; set; }
}
