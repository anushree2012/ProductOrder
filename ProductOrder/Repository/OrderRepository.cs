using ProductOrder.Entities;

namespace ProductOrder.Repository;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public void Save(Order order)
    {
        context.Orders.Add(order);
        context.SaveChanges();
    }
}

