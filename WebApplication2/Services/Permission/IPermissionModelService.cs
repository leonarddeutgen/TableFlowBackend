using WebApplication2.Data.Entities;

namespace WebApplication2.Services;

public interface IPermissionModelService
{
    Task<List<PermissionModel?>> GetAllOrganisationsAsync();
    Task<PermissionModel?> GetPermissionModelByIdAsync(int id);
}