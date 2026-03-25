using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;

namespace TableFlow.Repositories;

public interface ICategoriesRepository
{
    Task<List<Category>> GetCategoriesByOrgId(int orgId);
    Task AddCategory(Category category);
    
    Task <Category?> GetCategoryById(int id);
    Task<Category?> GetCategoryByOrgIdAndName(CreateCategoryDto dto);
    Task SaveChangesAsync();
}