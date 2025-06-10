namespace ProductOrder.Entities;

public class CartItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Product Product { get; private set; }
    public int Quantity { get; set; }
    public CartItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }
    // EF Core needs this
    private CartItem(){}
}