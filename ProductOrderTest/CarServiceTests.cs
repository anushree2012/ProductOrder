using Moq;
using ProductOrder;
using ProductOrder.Entities;
using ProductOrder.Service;

namespace ProductOrderTest;

public class CarServiceTests
{
    private readonly Mock<IOrderRepository> _mockOrderRepository;

    public CarServiceTests()
    {
        _mockOrderRepository= new Mock<IOrderRepository>();
        _mockOrderRepository.Setup(x=>x.Save(It.IsAny<Order>())).Verifiable();
    }
    [Fact]
    public void NoProductAddToCartWithQuantityLessThanOrEqualToZero()
    {
        var cartService = new CartService(_mockOrderRepository.Object);
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
        var cartService = new CartService(_mockOrderRepository.Object);
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

    [Fact]

    public void PlaceOrderWithProductQuantity()
    {
        var cartService = new CartService(_mockOrderRepository.Object);
        var product = new Product()
        {
            Price = new decimal(100.00),
            Name = "Laptop"
        };
        
        cartService.AddToCart(product, 2);
        var order= cartService.Checkout();
        
        Assert.Equal(order.Total, product.Price * 2);
        Assert.Equal(cartService.GetCartItems().Count,0);
    }
}