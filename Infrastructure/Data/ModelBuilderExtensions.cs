namespace MDP.Infrastructure.Data;
using MDP.Domain.Entities.Base;
using MDP.Infrastructure.Utility;
using Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtensions
{
  public static void AddQueryFilters(this ModelBuilder modelBuilder)
  {
    var entityTypes = modelBuilder.Model.GetEntityTypes()
        .Where(t => typeof(IDeleteEntity).IsAssignableFrom(t.ClrType));

    foreach (var entityType in entityTypes)
    {
      var method = typeof(ModelBuilderExtensions).GetMethod(nameof(SetQueryFilter), System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)?.MakeGenericMethod(entityType.ClrType);

      method?.Invoke(null, new object[] { modelBuilder });
    }
  }

  private static void SetQueryFilter<TEntity>(ModelBuilder modelBuilder) where TEntity : class, IDeleteEntity
  {
    modelBuilder.Entity<TEntity>().HasQueryFilter(e => !e.IsDeleted);
  }

  public static void ChangeNameToSnakeCaseLower(this ModelBuilder modelBuilder)
  {
    foreach (var entity in modelBuilder.Model.GetEntityTypes())
    {
      entity.SetTableName(entity.GetTableName().ToSnakeCase());

      foreach (var property in entity.GetProperties())
      {
        property.SetColumnName(property.GetColumnName().ToSnakeCase());
      }

      foreach (var key in entity.GetKeys())
      {
        key.SetName(key.GetName().ToSnakeCase());
      }

      foreach (var key in entity.GetForeignKeys())
      {
        key.PrincipalKey.SetName(key.PrincipalKey.GetName().ToSnakeCase());
        key.SetConstraintName(key.GetConstraintName().ToSnakeCase());
      }

      foreach (var index in entity.GetIndexes())
      {
        index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
      }
    }
  }
}
