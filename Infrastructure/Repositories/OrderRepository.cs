using MDP.Domain.Entities;
using MDP.Domain.Interfaces;
using MDP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MDP.Infrastructure.Repositories;


public class OrderRepository : IOrderRepository
{
  private readonly AppDbContext _context;

  public OrderRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Order> GetByIdAsync(int id)
  {
    return await _context.Orders.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Order not found");
  }

  public async Task<IEnumerable<Order>> GetAllAsync()
  {
    return await _context.Orders.Include(x => x.Items).ToListAsync();
  }

  public async Task AddAsync(Order order)
  {
    await _context.Orders.AddAsync(order);
    await _context.SaveChangesAsync();
  }

  public async Task UpdateAsync(Order order)
  {
    _context.Orders.Update(order);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteAsync(int id)
  {
    var order = await _context.Orders.FindAsync(id);
    if (order != null)
    {
      order.IsDeleted = true;
      await _context.SaveChangesAsync();
    }
  }
}