using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;

namespace WebApplication2.Repositories;

public interface ICategoriesRepository
{
    Task<List<Category>> GetCategoriesByOrgId(int orgId);
    Task AddCategory(Category category);
    
    Task <Category?> GetCategoryById(int id);
    Task<Category?> GetCategoryByOrgIdAndName(CreateCategoryDto dto);
    Task SaveChangesAsync();
}