using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;

namespace TableFlow.Services;

public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync(int orgId);
    Task<List<Product>> GetProdyctsByCategory(int categoryId);
    Task<Product?> CreateProductAsync(AddProductDto dto);
    
}