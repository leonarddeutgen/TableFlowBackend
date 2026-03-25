using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;
using WebApplication2.Repositories;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly ICategoriesService _categoriesService;

    public CategoriesController(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }
    
    [HttpGet("{orgId:int}")]
    public async Task<IActionResult> GetAllCategories(int orgId)
    {
        List<Category> allCategories = await _categoriesService.GetCategoriesByOrgId(orgId);
        
        return Ok(allCategories);
    }
    
    [HttpGet]
    [Route("{categoryId}")]
    public IActionResult GetCategoryById(int categoryId)
    {
        var category = _categoriesService.GetCategoryById(categoryId);
        return Ok(category);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCategory( CreateCategoryDto dto)
    {
        var category = await _categoriesService.CreateCategory(dto);
        return Ok(category);
    }
}


