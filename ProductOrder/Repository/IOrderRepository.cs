using ProductOrder.Entities;

namespace ProductOrder.Repository;

public interface IOrderRepository
{
    public void Save(Order order);
}