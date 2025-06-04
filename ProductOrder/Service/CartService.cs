using ProductOrder.Entities;

namespace ProductOrder.Service;

public class CartService: ICartService
{
    public Task AddToCart(Product product, int quantity)
    {
        throw new NotImplementedException();
    }

    public Task<List<CartItem>> GetCartItems()
    {
        throw new NotImplementedException();
    }
}