using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;

namespace WebApplication2.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetProducts(int orgId);
    Task<List<Product>> GetProductsByCategory(int categoryId);
    Task<Product?> GetProductByNameAndOrgId(string productName, int orgId);
    Task AddProduct(Product product);
    Task SaveChangesAsync();
}