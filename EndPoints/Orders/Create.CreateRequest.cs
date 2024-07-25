using System.Text.Json.Serialization;
using System.Windows.Input;
using MDP.Domain.Entities;

namespace MDP.EndPoints.Orders;

public class CreateRequest
{

  public string CustomerName { get; set; }
  public DateTime OrderDate { get; set; }

  public Address ShippingAddress { get; set; }
  public Address? DeliveryAddress { get; set; }
  public string Phone { get; set; }
  public string Email { get; set; }
}
