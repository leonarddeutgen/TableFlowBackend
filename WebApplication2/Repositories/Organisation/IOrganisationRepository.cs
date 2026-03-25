using WebApplication2.Data.Dtos;
using WebApplication2.Data.Entities;

namespace WebApplication2.Repositories;

public interface IOrganisationRepository
{
    Task<Organisation> GetOrganisationByIdAsync(int orgId);
    
    Task<List<Organisation>> GetOrganisationsByUserIdAsync(int userId);
    
    Task<Organisation> GetOrganisationByNameAndUserId(CreateOrganisationDto dto);
    
    Task AddOrganisationAsync(Organisation organisation);

    Task SaveChangesAsync();
    Task<int> GetDailySalesAsync(int orgId, DateTime from, DateTime to);
}