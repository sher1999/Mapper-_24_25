
using Domain.Entities;
using Microsoft.EntityFrameworkCore ;


namespace Infrastructure.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options){

    }

  public DbSet<Customer> Customers { get; set; }
  public DbSet<Address> Addresses { get; set; }
  public  DbSet<Order> Orders { get; set; }
  public  DbSet<Product> Products { get; set; }
  public DbSet<OrderItem> OrderItems { get; set; }
  public DbSet<Album> Albums { get; set; }
  public DbSet<Supplier> Suppliers { get; set; }


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
      modelBuilder.Entity<OrderItem>()
          .HasKey(bc => new { bc.OrderId, bc.ProductId });  
      modelBuilder.Entity<OrderItem>()
          .HasOne(bc => bc.Order)
          .WithMany(b => b.OrderItems)
          .HasForeignKey(bc => bc.OrderId);  
      modelBuilder.Entity<OrderItem>()
          .HasOne(bc => bc.Product)
          .WithMany(c => c.OrderItems)
          .HasForeignKey(bc => bc.ProductId);
  }


}
