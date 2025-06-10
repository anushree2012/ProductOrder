using Microsoft.Extensions.Caching.Memory;
using ProductOrder.Entities;
using ProductOrder.Repository;

namespace ProductOrder.Service;

public class CartService(IOrderRepository orderRepository, IMemoryCache memoryCache) : ICartService
{
    private const string CartKey = "cart_items";

    public void AddToCart(Product product, int quantity)
    {
        var cart = GetCartInternal();
        if (quantity <= 0)
            return;
        var itemExist= cart.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
        if(itemExist == null)
            cart.Add(new CartItem(product, quantity));
        else
        {
            itemExist.Quantity += quantity;
        }
        memoryCache.Set(CartKey, cart);
    }

    public List<CartItem> GetCartItems()
    {
        return GetCartInternal();
    }

    public Order Checkout()
    {
        var cart = GetCartInternal();
        var order = new Order(cart);
        orderRepository.Save(order);
        memoryCache.Remove(CartKey);
        return order;
    }
    private List<CartItem> GetCartInternal()
    {
        return (memoryCache.TryGetValue(CartKey, out List<CartItem>? cart)
            ? cart
            : new List<CartItem>())!;
    }
}