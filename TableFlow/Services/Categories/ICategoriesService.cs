using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;

namespace TableFlow.Services;

public interface ICategoriesService
{
    Task<List<Category>> GetCategoriesByOrgId(int orgId);
    Task<Category?> CreateCategory(CreateCategoryDto dto);
    
    Task<Category> GetCategoryById(int id);
}