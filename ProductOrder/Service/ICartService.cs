using ProductOrder.Entities;

namespace ProductOrder.Service;

public interface ICartService
{
    public Task AddToCart(Product product, int quantity);
    public Task<List<CartItem>> GetCartItems();
}