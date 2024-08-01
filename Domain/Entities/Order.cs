using MDP.Domain.Entities.Base;

namespace MDP.Domain.Entities;

public class Order : BaseEntity, IDeleteEntity
{

  public string CustomerName { get; set; } = string.Empty;
  public DateTime OrderDate { get; set; }
  public Address ShoppingAddress { get; set; }
  public Address DeliverAddress { get; set; }
  public string Phone { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;

  public DateTime UpdatedAt { get; set; }
  public bool IsCancelled { get; set; }
  public List<OrderItem> Items { get; set; } = [];

  public bool IsDeleted { get; set; }

}

public enum OrderStatus
{
  Pending,
  Processing,
  Shipped,
  Delivered,
  Cancelled
}

public record Address(string Street, string City, string State, string ZipCode);