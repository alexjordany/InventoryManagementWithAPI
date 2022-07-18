using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Persistence;

public class InventoryManagementDbContext : DbContext
{
    public InventoryManagementDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductInventory>().HasKey(pi => new { pi.ProductId, pi.InventoryId });

        modelBuilder.Entity<ProductInventory>().HasOne(pi => pi.Product).WithMany(p => p.ProductInventories).HasForeignKey(pi => pi.ProductId);

        modelBuilder.Entity<ProductInventory>().HasOne(pi => pi.Inventory).WithMany(i => i.ProductInventories).HasForeignKey(pi => pi.InventoryId);

        modelBuilder.Entity<Inventory>().HasData(
            new Inventory { InventoryId = 1, InventoryName = "Engine", Price = 1000, Quantity = 1 },
            new Inventory { InventoryId = 2, InventoryName = "Body", Price = 400, Quantity = 1 },
            new Inventory { InventoryId = 3, InventoryName = "Wheels", Price = 100, Quantity = 4 },
            new Inventory { InventoryId = 4, InventoryName = "Seat", Price = 50, Quantity = 5 },
            new Inventory { InventoryId = 5, InventoryName = "Electric Engine", Price = 8000, Quantity = 2 },
            new Inventory { InventoryId = 6, InventoryName = "Battery", Price = 400, Quantity = 5 }
        );
    }
}

