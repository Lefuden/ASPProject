using ASPProjectBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPProjectBackend.Data;

//public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<Customer, IdentityRole<int>, int>(options)
//{
//    public DbSet<Customer> Customers { get; set; }
//    public DbSet<Product> Products { get; set; }
//    public DbSet<Order> Orders { get; set; }
//    public DbSet<OrderProduct> OrderProducts { get; set; }
//    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
//    public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }
//}

public class ApplicationDbContext : IdentityDbContext<Customer, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShoppingCartProduct>()
            .HasIndex(sci => new { sci.ShoppingCartId, sci.ProductId })
            .IsUnique();

        // Configure one-to-one relationship between Customer and ShoppingCart
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.ShoppingCart)
            .WithOne(sc => sc.Customer)
            .HasForeignKey<ShoppingCart>(sc => sc.CustomerId);

        base.OnModelCreating(modelBuilder);
    }
}