namespace ProductOrder.Entities;

public class CartItem(Product product, int quantity)
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
}