using Microsoft.EntityFrameworkCore;
using ProductOrder;
using ProductOrder.Entities;
using ProductOrder.Repository;

namespace ProductOrderTest;

public class OrderRepositoryTests
{
    [Fact]
    public void ShouldSaveOrderInDatabase()
    {
        var product = new Product()
        {
            Name = "Test Product",
            Price = 100.00M
        };
        var cartItem = new CartItem(product, 1);
        var order = new Order(new List<CartItem>{cartItem});
        var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("ProductOrderTest").Options;
        var context= new AppDbContext(options);

        var orderRepository = new OrderRepository(context);
        orderRepository.Save(order);
        
        var result= context.Orders.FirstOrDefault(x=>x.OrderId == order.OrderId);
        Assert.NotNull(result);
        Assert.Equal(order.OrderId, result.OrderId);
        Assert.Equal(order.Total, result.Total);
    }
}