namespace ProductOrder.Entities;

public class Order
{
    public Guid OrderId { get; private set; } = Guid.NewGuid();
    public List<CartItem> Items { get;} = new();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public decimal Total => Items.Sum(i => i.Product.Price * i.Quantity);

    public Order(List<CartItem> items)
    {
        Items = items;
    }

    // EF Core needs this
    private Order() { }
}