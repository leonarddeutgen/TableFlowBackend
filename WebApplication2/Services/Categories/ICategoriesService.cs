using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;

namespace WebApplication2.Services;

public interface ICategoriesService
{
    Task<List<Category>> GetCategoriesByOrgId(int orgId);
    Task<Category?> CreateCategory(CreateCategoryDto dto);
    
    Task<Category> GetCategoryById(int id);
}