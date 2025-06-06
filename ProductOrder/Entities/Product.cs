namespace ProductOrder.Entities;

public class Product
{
    public string ProductId { get; private set; }= Guid.NewGuid().ToString();
    public decimal Price { get; set; }
    public string Name { get; set; }

    //EF core needs this
    public Product()
    {
        
    }
}