using ProductOrder.Entities;

namespace ProductOrder.Service;

public class CartService: ICartService
{
    private readonly List<CartItem> _cartItems = new();
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
}