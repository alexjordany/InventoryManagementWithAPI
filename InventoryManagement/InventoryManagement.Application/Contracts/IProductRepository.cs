namespace InventoryManagement.Application.Contracts;

public interface IProductRepository : IAsyncRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByName(string name);
}

