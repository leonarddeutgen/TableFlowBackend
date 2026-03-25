using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;

namespace TableFlow.Services;

public interface IOrganisationService
{
    Task<Organisation> GetOrganisationByIdAsync(int id);
    Task<List<Organisation>> GetAllOrganisationsByUserIdAsync(int userId);
    
    Task<Organisation?> CreateOrganisationAsync(CreateOrganisationDto dto);
}