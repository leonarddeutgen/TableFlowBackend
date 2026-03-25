using TableFlow.Data;
using TableFlow.Data.Entities;

namespace TableFlow.Repositories;

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