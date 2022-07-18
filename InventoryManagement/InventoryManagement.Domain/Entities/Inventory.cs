using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InventoryManagement.Domain.Shared;

namespace InventoryManagement.Domain.Entities;

public class Inventory : AuditableEntity
{
    public int InventoryId { get; set; }
    public string InventoryName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public double Price { get; set; }

    public List<ProductInventory> ProductInventories { get; set; }
}

