using MDP.Domain.Entities;

namespace MDP.EndPoints.Orders;

public class Response
{
  public Guid Id { get; set; }
  public string CustomerName { get; set; }
  public Address? ShoppingAddress { get; set; }
  public string Phone { get; set; }
  public string Email { get; set; }
  public OrderStatus Status { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public List<OrderItem> Items { get; set; } = [];
}
