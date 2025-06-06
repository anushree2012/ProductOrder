using Microsoft.AspNetCore.Mvc;
using ProductOrder.Dto;
using ProductOrder.Entities;
using ProductOrder.Service;

namespace ProductOrder.Controller;

[ApiController]
[Route("api/[controller]")]
public class CartController(ICartService cartService) : ControllerBase
{
    [HttpPost("add")]
    public IActionResult AddToCart([FromBody] ProductDto dto)
    {
        var product = new Product()
        {
            Name = dto.Name,
            Price = dto.Price,
        };
        cartService.AddToCart(product, dto.Quantity);
        return Ok("Product added to cart");
    }

    [HttpPost("checkout")]
    public IActionResult Checkout()
    {
        var order = cartService.Checkout();
        return Ok(new { orderId = order.OrderId, total = order.Total });
    }
}