using TableFlow.Data.Entities;

namespace TableFlow.Services;

public interface IPermissionModelService
{
    Task<List<PermissionModel?>> GetAllOrganisationsAsync();
    Task<PermissionModel?> GetPermissionModelByIdAsync(int id);
}