namespace MDP.Infrastructure.Data;

using System.Reflection;
using MDP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public DbSet<Order> Orders { get; set; }
  public DbSet<OrderItem> OrderItems { get; set; }


  public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    builder.AddQueryFilters();
    builder.ChangeNameToSnakeCaseLower();

    base.OnModelCreating(builder);
  }
}