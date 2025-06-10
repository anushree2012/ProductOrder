using Microsoft.Extensions.Caching.Memory;
using Moq;
using ProductOrder.Entities;
using ProductOrder.Repository;
using ProductOrder.Service;

namespace ProductOrderTest;

public class CarServiceTests
{
    private readonly CartService _cartService;

    public CarServiceTests()
    {
        Mock<IOrderRepository> mockOrderRepository = new();
        var memoryCache = new MemoryCache(new MemoryCacheOptions());
        mockOrderRepository.Setup(x=>x.Save(It.IsAny<Order>())).Verifiable();
        _cartService = new CartService(mockOrderRepository.Object, memoryCache);
    }
    [Fact]
    public void NoProductAddToCartWithQuantityLessThanOrEqualToZero()
    {
        var product = new Product()
        {
            Price = new decimal(100.00),
            Name = "Laptop"
        };
        
        _cartService.AddToCart(product, 0);
        var cartItems= _cartService.GetCartItems();
        
        Assert.Empty(cartItems);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void ShouldAddProductToCartWithQuantity(int productQuantity)
    {
        var product = new Product()
        {
            Price = new decimal(100.00),
            Name = "Laptop"
        };
        
        _cartService.AddToCart(product, productQuantity);
        var cartItems= _cartService.GetCartItems();
        
        Assert.Single(cartItems);
        Assert.Equal(cartItems.FirstOrDefault()?.Quantity,productQuantity);
    }

    [Fact]

    public void PlaceOrderWithProductQuantity()
    {
        var product = new Product()
        {
            Price = new decimal(100.00),
            Name = "Laptop"
        };
        
        _cartService.AddToCart(product, 2);
        var order= _cartService.Checkout();
        
        Assert.Equal(order.Total, product.Price * 2);
        Assert.Equal(_cartService.GetCartItems().Count,0);
    }
}