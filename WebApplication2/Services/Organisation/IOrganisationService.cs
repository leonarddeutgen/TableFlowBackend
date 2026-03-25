using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;

namespace WebApplication2.Services;

public interface IOrganisationService
{
    Task<Organisation> GetOrganisationByIdAsync(int id);
    Task<List<Organisation>> GetAllOrganisationsByUserIdAsync(int userId);
    
    Task<Organisation?> CreateOrganisationAsync(CreateOrganisationDto dto);
}