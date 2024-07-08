using ASPProjectBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPProjectBackend.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User, IdentityRole<int>, int>(options)
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    //public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    //public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }
    public DbSet<GameLibrary> GameLibraries { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>()
            .Property(o => o.TotalOrderPrice)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<OrderProduct>()
            .Property(op => op.TotalPrice)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<OrderProduct>()
            .Property(op => op.UnitPrice)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Order>()
            .HasOne(o => o.ShippingAddress)
            .WithMany()
            .HasForeignKey(o => o.ShippingAddressId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.BillingAddress)
            .WithMany()
            .HasForeignKey(o => o.BillingAddressId)
            .OnDelete(DeleteBehavior.NoAction);

        //modelBuilder.Entity<ShoppingCartProduct>()
        //    .HasIndex(sci => new { sci.ShoppingCartId, sci.ProductId })
        //    .IsUnique();

        //modelBuilder.Entity<User>()
        //    .HasOne(c => c.ShoppingCart)
        //    .WithOne(sc => sc.User)
        //    .HasForeignKey<ShoppingCart>(sc => sc.UserId);
    }
}