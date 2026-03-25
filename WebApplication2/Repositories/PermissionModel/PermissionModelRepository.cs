using WebApplication2.Data;
using WebApplication2.Data.Entities;

namespace WebApplication2.Repositories;

public class PermissionModelRepository : IPermissionModelRepository
{
    private readonly AppDbContext _context;

    public PermissionModelRepository(AppDbContext context)
    {
        _context = context;
    }
    public Task<List<PermissionModel>> GetAllOrganisationsAsync()
    {
         return Task.FromResult(_context.PermissionModels.ToList());
    }

    public Task<PermissionModel?> GetPermissionModelByIdAsync(int id)
    {
        return Task.FromResult(_context.PermissionModels.Find(id));
    }
}