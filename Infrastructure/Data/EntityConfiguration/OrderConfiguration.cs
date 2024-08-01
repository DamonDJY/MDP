using MDP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDP.Infrastructure.Data.EntityConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
  public void Configure(EntityTypeBuilder<Order> builder)
  {
    builder.ComplexProperty(e => e.ShoppingAddress, a =>
    {
      a.Property(p => p.Street).HasMaxLength(100);
      a.Property(p => p.City).HasMaxLength(50);
      a.Property(p => p.State).HasMaxLength(50);
      a.Property(p => p.ZipCode).HasMaxLength(10);
    });

    builder.ComplexProperty(e => e.DeliverAddress, a =>
    {
      a.Property(p => p.Street).HasMaxLength(100);
      a.Property(p => p.City).HasMaxLength(50);
      a.Property(p => p.State).HasMaxLength(50);
      a.Property(p => p.ZipCode).HasMaxLength(10);
    });

    builder.HasMany(e => e.Items)
        .WithOne()
        .HasForeignKey(e => e.OrderId);
  }
}
