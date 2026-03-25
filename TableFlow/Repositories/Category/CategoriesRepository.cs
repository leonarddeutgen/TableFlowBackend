using Microsoft.EntityFrameworkCore;
using TableFlow.Data;
using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;

namespace TableFlow.Repositories;

public class CategoriesRepository : ICategoriesRepository
{
    private AppDbContext _context;

    public CategoriesRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Category>> GetCategoriesByOrgId(int orgId)
    {
        var allCategories = await _context.Categories
            .Where(c => c.OrganisationId == orgId)
            .OrderBy(c => c.CategoryName).ToListAsync();

        return allCategories;
    }

    public Task AddCategory(Category category)
    {
        _context.Categories.Add(category);
        return Task.CompletedTask;
    }

    public async Task<Category?> GetCategoryById(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
        return category;
    }

    public async Task<Category?> GetCategoryByOrgIdAndName(CreateCategoryDto dto)
    {
        var category = await _context.Categories.Where(c => c.OrganisationId == dto.OrgId && c.CategoryName == dto.Name)
            .FirstOrDefaultAsync();
      return category;
    }

    public async Task SaveChangesAsync()
    {
      await _context.SaveChangesAsync();
    }
}