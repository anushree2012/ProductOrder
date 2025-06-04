using ProductOrder.Entities;

namespace ProductOrder;

public class Order
{
    public Guid OrderId { get; } = Guid.NewGuid();
    private List<CartItem> Items { get; set; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public decimal Total() => Items.Sum(x=>x.Product.Price * x.Quantity);

    public Order(List<CartItem> items)
    {
        Items = items;
    }
    
}