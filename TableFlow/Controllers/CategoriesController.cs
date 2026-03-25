using Microsoft.AspNetCore.Mvc;
using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;
using TableFlow.Services;
using TableFlow.Data;
using TableFlow.Repositories;

namespace TableFlow.Controllers;

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


