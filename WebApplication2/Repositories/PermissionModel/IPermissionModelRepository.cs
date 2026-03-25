using WebApplication2.Data.Entities;

namespace WebApplication2.Repositories;

public interface IPermissionModelRepository
{
    Task<List<PermissionModel>> GetAllOrganisationsAsync();
    Task<PermissionModel?> GetPermissionModelByIdAsync(int id);
}