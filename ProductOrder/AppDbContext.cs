using Microsoft.EntityFrameworkCore;
using ProductOrder.Entities;

namespace ProductOrder;

public class AppDbContext: DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
        modelBuilder.Entity<Order>().HasKey(o => o.OrderId);

        modelBuilder.Entity<Order>()
            .OwnsMany(o => o.Items, ci =>
            {
                ci.WithOwner().HasForeignKey("OrderId"); // add FK back to Order
                ci.HasKey(c => c.Id);                    // define PK on CartItem
                ci.Property(c => c.Id);                  // make sure EF sees it
            });

    }
}