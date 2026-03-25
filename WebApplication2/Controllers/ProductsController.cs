using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;
using WebApplication2.Services;

namespace WebApplication2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet("all/{orgId:int}")]
    public async Task<IActionResult> GetAllProducts(int orgId)
    {
        var allProductsForOrg = await _productService.GetAllProductsAsync(orgId);
        return Ok(allProductsForOrg);
    }
    
    [HttpGet]
    [Route("{categoryId:int}")]
    public async Task<IActionResult> GetProductsByCategory(int categoryId)
    {
        var productsForCategory = await _productService.GetProdyctsByCategory(categoryId);
        return Ok(productsForCategory);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(AddProductDto dto)
    {
        var product = await _productService.CreateProductAsync(dto);
        return Ok(product);
    }
}