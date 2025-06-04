using ProductOrder.Entities;

namespace ProductOrder.Service;

public interface ICartService
{
    public void AddToCart(Product product, int quantity);
    public List<CartItem> GetCartItems();
}