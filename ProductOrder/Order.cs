using ProductOrder.Entities;

namespace ProductOrder;

public class Order(List<CartItem> items)
{
    public Guid OrderId { get; } = Guid.NewGuid();
    private List<CartItem> Items { get; set; } = items;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public decimal Total => Items.Sum(x=>x.Product.Price * x.Quantity);
}