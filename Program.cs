using MDP.Application.Commands;
using MDP.Application.Queries;
using MDP.Domain.Interfaces;
using MDP.Infrastructure.Data;
using MDP.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FastEndpoints;
using System.Reflection;
using FastEndpoints.Swagger;
using MDP.Infrastructure.Utility;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
ConfigureMediatR();
builder.Services.AddFastEndpoints().SwaggerDocument(o =>
                {
                    o.ShortSchemaNames = true;
                });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureDeleted(); // 删除数据库
        dbContext.Database.EnsureCreated(); // 创建数据库
    }
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseFastEndpoints(c =>
{
    c.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;

    c.Serializer.ResponseSerializer = (rsp, dto, cType, jCtx, ct) =>
    {
        rsp.ContentType = cType;
        return rsp.WriteAsync(JsonHelper.Serialize(dto), ct);
    };
}).UseSwaggerGen(); ;

app.Run();

void ConfigureMediatR()
{
    var mediatRAssemblies = new[]
  {
  //Assembly.GetAssembly(typeof(Contributor)), // Core
  Assembly.GetAssembly(typeof(GetOrderByIdQueryHandler)) // UseCases
};
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!));
    //builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    //builder.Services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
}
