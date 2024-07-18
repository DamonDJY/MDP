namespace MDP.Domain.Entities.Base;

public class BaseEntity
{
  public Guid Id { get; set; }
  public OrderStatus Status { get; set; }
  public DateTime CreatedAt { get; set; }
}
