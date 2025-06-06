using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductOrder.Controller;
using ProductOrder.Dto;
using ProductOrder.Entities;
using ProductOrder.Service;

namespace ProductOrderTest;

public class CartControllerTests
{
    [Fact]
    public void ShouldAddProductToCart()
    {
        var cartService= new Mock<ICartService>();
        var request = new ProductDto()
        {
            Name = "Test Product",
            Price = 10,
            Quantity = 1
        };
        cartService.Setup(x => x.AddToCart(It.IsAny<Product>(), It.IsAny<int>()));
        
        var controller = new CartController(cartService.Object);
        var result= controller.AddToCart(request);
        
        var viewResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(viewResult.Value,"Product added to cart");
        cartService.Verify(x => x.AddToCart(It.IsAny<Product>(), It.IsAny<int>()), Times.Once);
    }
    [Fact]
    public void ShouldCheckoutTheProduct()
    {
        var cartService= new Mock<ICartService>();
        var product = new Product()
        {
            Name = "Test Product",
            Price = 10
        };
        var cartItem = new CartItem(product, 1);
        var order = new Order(new List<CartItem>() { cartItem });
        cartService.Setup(x => x.Checkout()).Returns(order);
        var expected = new { orderId = order.OrderId, total = order.Total };
        
        var controller = new CartController(cartService.Object);
        var result= controller.Checkout();
        
        var viewResult = Assert.IsType<OkObjectResult>(result);
        cartService.Verify(x => x.Checkout(), Times.Once);
        Assert.Equal(viewResult.Value?.ToString(),expected.ToString());
    }
}