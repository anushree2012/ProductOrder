// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Configure the HTTP request pipeline.

using Microsoft.EntityFrameworkCore;
using ProductOrder;
using ProductOrder.Repository;
using ProductOrder.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ECommerceDb"));

builder.Services.AddMemoryCache();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICartService, CartService>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.Run();
