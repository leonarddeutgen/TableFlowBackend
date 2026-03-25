
using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;
using TableFlow.Repositories;

namespace TableFlow.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<List<Product>> GetAllProductsAsync(int orgId)
    {
       var products = await _productRepository.GetProducts(orgId);
       if (products is null)
       {
           throw new ApplicationException("No products found");
       }
       return products;
    }

    public async Task<List<Product>> GetProdyctsByCategory(int categoryId)
    {
        var products = await _productRepository.GetProductsByCategory(categoryId);
        if (products is null)
        {
            throw new ApplicationException($"No products found with categoryId: {categoryId}");
        }
        return products;
    }

    public async Task<Product?> CreateProductAsync(AddProductDto dto)
    {
        var existingProduct = await _productRepository.GetProductByNameAndOrgId(dto.ProductName, dto.OrganisationId);
        if (existingProduct != null)
        {
            throw new ApplicationException($"Product with name {dto.ProductName} already exists in organisation {dto.OrganisationId}");
        }
        
        //Skapa en factory för denna.
        var product = new Product
        {
            ProductName = dto.ProductName,
            ProductPrice = dto.ProductPrice,
            CategoryId = dto.CategoryId,
            OrganisationId = dto.OrganisationId,
            IsActive = true
        };
        
        await _productRepository.AddProduct(product);
        await _productRepository.SaveChangesAsync();

        return product;
    }
}