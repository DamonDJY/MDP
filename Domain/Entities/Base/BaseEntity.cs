using System.ComponentModel.DataAnnotations;

namespace MDP.Domain.Entities.Base;

public class BaseEntity
{
  [Key]
  public int Id { get; set; }
  public OrderStatus Status { get; set; }
  public DateTime CreatedAt { get; set; }
}
