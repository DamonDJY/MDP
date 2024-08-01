using MDP.Domain.Entities.Base;

namespace MDP.Domain.Entities;

public class OrderItem : BaseEntity
{
  public int OrderId { get; set; }
  public int ProductId { get; set; }
  public string ProductName { get; set; }
  public decimal Price { get; set; }
  public int Quantity { get; set; }
  public decimal Total { get; set; }

}
