using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;
using TableFlow.Repositories;

namespace TableFlow.Services;

public class OrganisationService : IOrganisationService
{
    private readonly IOrganisationRepository _organisationRepository;

    public OrganisationService(IOrganisationRepository organisationRepository)
    {
        _organisationRepository = organisationRepository;
    }
    public Task<Organisation> GetOrganisationByIdAsync(int id)
    {
        var org = _organisationRepository.GetOrganisationByIdAsync(id);
        if (org == null)
        {
            throw new Exception("Organisation not found");
        }
        return org;
    }

    public async Task<List<Organisation>> GetAllOrganisationsByUserIdAsync(int userId)
    {
        Console.WriteLine($"USER ID: {userId}");
        
        var orgs = await _organisationRepository.GetOrganisationsByUserIdAsync(userId);
        if (orgs == null)
        {
            throw new Exception($"Organisations for user id {userId} not found.");
        }
        return orgs;
    }

    public async Task<Organisation?> CreateOrganisationAsync(CreateOrganisationDto dto)
    {
        var orgExist = await _organisationRepository.GetOrganisationByNameAndUserId(dto);

        if (orgExist != null)
        {
            throw new Exception($"Organisation with name ´{dto.Name}´ already exists");
        }
        
        var org = new Organisation
        {
            OrganisationName = dto.Name,
            UserId = dto.UserId
        }; 
        
        await _organisationRepository.AddOrganisationAsync(org); 
        await _organisationRepository.SaveChangesAsync();
       
        return org;
    }
}
