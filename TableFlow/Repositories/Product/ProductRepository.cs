using TableFlow.Data;
using TableFlow.Data.Entities;

namespace TableFlow.Repositories;

public class ProductRepository : IProductRepository
{
    private AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public Task<List<Product>> GetProducts(int orgId)
    {
        List<Product> allProducts = _context.Products
            .Where(p=> p.OrganisationId == orgId && p.IsActive == true)
            .OrderBy(p => p.ProductName).ToList();
        
        return Task.FromResult(allProducts);
    }
    public Task<List<Product>> GetProductsByCategory(int categoryId)
    {
        List<Product> products = _context.Products
            .Where(p => p.CategoryId == categoryId && p.IsActive == true)
            .OrderBy(p=>p.ProductName)
            .ToList();
        return Task.FromResult(products);
    }
    public Task<Product?> GetProductByNameAndOrgId(string productName, int orgId)
    {
        var product = _context.Products
            .FirstOrDefault(p => p.ProductName == productName && p.OrganisationId == orgId);
        return Task.FromResult(product);
    }

    public Task AddProduct(Product product)
    {
        _context.Products.Add(product);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync()
    {
        _context.SaveChanges();
        return Task.CompletedTask;
    }
}