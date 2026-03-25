using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;
using WebApplication2.Repositories;

namespace WebApplication2.Services;

public class CategoriesServices : ICategoriesService
{
    private readonly ICategoriesRepository _categoriesRepository;

    public CategoriesServices(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }
    
    public async Task<List<Category>> GetCategoriesByOrgId(int orgId)
    {
        var allCategories = await _categoriesRepository.GetCategoriesByOrgId(orgId);

        if (allCategories == null)
        {
            throw new ApplicationException("No Categories found");
        }
        return allCategories;
    }
    
    public async Task<Category?> CreateCategory(CreateCategoryDto dto)
    {
        var existingCategory = await _categoriesRepository.GetCategoryByOrgIdAndName(dto);

        if (existingCategory != null)
        {
            throw new ApplicationException($"Category with name: ´{dto.Name }´ already exists");
        }
        
        var newCategory = new Category
        {
            CategoryName = dto.Name,
            OrganisationId = dto.OrgId
        };
        
        await _categoriesRepository.AddCategory(newCategory);
        await _categoriesRepository.SaveChangesAsync();
        
        return newCategory;
    }

    public async Task<Category> GetCategoryById(int id)
    {
        var category = await _categoriesRepository.GetCategoryById(id);
        if (category == null)
        {
            throw new ApplicationException($"Category with id: {id} not found");
        }
        
        return category;
    }
}