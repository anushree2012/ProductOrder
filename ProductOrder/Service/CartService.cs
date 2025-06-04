using ProductOrder.Entities;

namespace ProductOrder.Service;

public class CartService(IOrderRepository orderRepository) : ICartService
{
    private readonly List<CartItem> _cartItems = [];

    public void AddToCart(Product product, int quantity)
    {
        if (quantity <= 0)
            return;
        var itemExist= _cartItems.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
        if(itemExist == null)
            _cartItems.Add(new CartItem(product, quantity));
        else
        {
            itemExist.Quantity += quantity;
        }
    }

    public List<CartItem> GetCartItems()
    {
        return _cartItems;
    }

    public Order Checkout()
    {
        var order = new Order([.._cartItems]);
        orderRepository.Save(order);
        _cartItems.Clear();
        return order;
    }
}

public interface IOrderRepository
{
    public void Save(Order order);
}