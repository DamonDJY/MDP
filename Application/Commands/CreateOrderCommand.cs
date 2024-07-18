using Ardalis.Result;
using MDP.Domain.Entities;
using MediatR;

namespace MDP.Application.Commands;
public class CreateOrderCommand : Ardalis.SharedKernel.ICommand<Result<Guid>>
{
  public string CustomerName { get; set; }
  public DateTime OrderDate { get; set; }

  public Address ShippingAddress { get; set; }
  public Address? DeliveryAddress { get; set; }
  public string Phone { get; set; }
  public string Email { get; set; }

}


