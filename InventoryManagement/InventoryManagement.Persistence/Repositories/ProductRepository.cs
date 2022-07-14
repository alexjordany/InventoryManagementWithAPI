using InventoryManagement.Application.Contracts;
using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(InventoryManagementDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Product>> GetProductsByName(string name)
    {
        var productsByName = await _dbContext.Products
            .Where(x => (x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrWhiteSpace(name)) &&
            x.Active == true).ToListAsync();
        return productsByName;
    }
}

