using Microsoft.EntityFrameworkCore;
using ProductOrder.Entities;

namespace ProductOrder;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
        modelBuilder.Entity<Order>().HasKey(o => o.OrderId);

        modelBuilder.Entity<Order>()
            .OwnsMany(o => o.Items, ci =>
            {
                ci.WithOwner().HasForeignKey("OrderId"); 
                ci.HasKey(c => c.Id);                    
                ci.Property(c => c.Id);                  
            });

    }
}