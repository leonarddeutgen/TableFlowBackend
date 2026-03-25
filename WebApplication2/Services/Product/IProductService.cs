using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;

namespace WebApplication2.Services;

public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync(int orgId);
    Task<List<Product>> GetProdyctsByCategory(int categoryId);
    Task<Product?> CreateProductAsync(AddProductDto dto);
    
}