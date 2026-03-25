using TableFlow.Data.Entities;
using TableFlow.Repositories;

namespace TableFlow.Services;

public class PermissionModelService : IPermissionModelService
{
    private readonly IPermissionModelRepository _repository;

    public PermissionModelService(IPermissionModelRepository repository)
    {
        _repository = repository;
    }
    public Task<List<PermissionModel>> GetAllOrganisationsAsync()
    {
        var allPermissions = _repository.GetAllOrganisationsAsync().Result;
        if (allPermissions is null)
        {
            throw new ApplicationException("No permissions found");
        }
        
        return Task.FromResult(allPermissions);
    }

    public Task<PermissionModel?> GetPermissionModelByIdAsync(int id)
    {
        var permission = _repository.GetPermissionModelByIdAsync(id);

        if (permission is null)
        {
            throw new ApplicationException("No permission found");
        }

        return permission;
    }
}