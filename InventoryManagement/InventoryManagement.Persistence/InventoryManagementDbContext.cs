using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Persistence;

public class InventoryManagementDbContext : DbContext
{
    public InventoryManagementDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Inventory> Inventories { get; set; }
}

