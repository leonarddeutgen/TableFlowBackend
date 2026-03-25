using TableFlow.Data.Entities;
using TableFlow.Data.Dtos;

namespace TableFlow.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetProducts(int orgId);
    Task<List<Product>> GetProductsByCategory(int categoryId);
    Task<Product?> GetProductByNameAndOrgId(string productName, int orgId);
    Task AddProduct(Product product);
    Task SaveChangesAsync();
}