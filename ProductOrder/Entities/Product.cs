namespace ProductOrder.Entities;

public class Product
{
    public string ProductId { get;  }= Guid.NewGuid().ToString();
    public decimal Price { get; set; }
    public string Name { get; set; }
}