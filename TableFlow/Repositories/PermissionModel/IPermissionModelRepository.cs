using TableFlow.Data.Entities;

namespace TableFlow.Repositories;

public interface IPermissionModelRepository
{
    Task<List<PermissionModel>> GetAllOrganisationsAsync();
    Task<PermissionModel?> GetPermissionModelByIdAsync(int id);
}