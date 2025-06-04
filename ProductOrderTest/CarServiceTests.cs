using ProductOrder.Entities;
using ProductOrder.Service;

namespace ProductOrderTest;

public class CarServiceTests
{
    [Fact]
    public void NoProductAddToCartWithQuantityLessThanOrEqualToZero()
    {
        var cartService = new CartService();
        var product = new Product()
        {
            Price = new decimal(100.00),
            Name = "Laptop"
        };
        
        cartService.AddToCart(product, 0);
        var cartItems= cartService.GetCartItems();
        
        Assert.Empty(cartItems);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void ShouldAddProductToCartWithQuantity(int productQuantity)
    {
        var cartService = new CartService();
        var product = new Product()
        {
            Price = new decimal(100.00),
            Name = "Laptop"
        };
        
        cartService.AddToCart(product, productQuantity);
        var cartItems= cartService.GetCartItems();
        
        Assert.Single(cartItems);
        Assert.Equal(cartItems.FirstOrDefault()?.Quantity,productQuantity);
    }
}