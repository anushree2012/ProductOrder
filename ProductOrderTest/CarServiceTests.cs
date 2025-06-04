using ProductOrder.Entities;
using ProductOrder.Service;

namespace ProductOrderTest;

public class CarServiceTests
{
    [Fact]
    public void ShouldAddProductToCartWithQuantity()
    {
        var cartService = new CartService();
        var product = new Product()
        {
            Price = new decimal(100.00),
            Name = "Laptop"
        };
        
        cartService.AddToCart(product, 1);
        var cartItems= cartService.GetCartItems();
        
        Assert.Single(cartItems.Result);
        Assert.Equal(cartItems.Result.Count, 1);
    }
}