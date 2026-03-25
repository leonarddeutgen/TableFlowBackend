using Microsoft.AspNetCore.Mvc;
using TableFlow.Data.Dtos;
using TableFlow.Services;
using TableFlow.Data;
using TableFlow.Data.Entities;

namespace TableFlow.Controllers;
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