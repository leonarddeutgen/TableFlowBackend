using Microsoft.EntityFrameworkCore;
using TableFlow.Data;
using TableFlow.Data.Dtos;
using TableFlow.Data.Entities;

namespace TableFlow.Repositories;

public class OrganisationRepository : IOrganisationRepository
{
    private readonly AppDbContext _context;

    public OrganisationRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Organisation> GetOrganisationByIdAsync(int orgId)
    {
        return await _context.Organisations
            .Include(o => o.Rooms)
            .ThenInclude(r => r.Tables)
            .Include(o => o.Categories)
            .Include(o => o.Products)
            .FirstOrDefaultAsync(o => o.OrganisationId == orgId);
    }

    public async Task<List<Organisation>> GetOrganisationsByUserIdAsync(int userId)
    {
        return await _context.Organisations
            .Where(o => o.UserId == userId)
            .ToListAsync();
    }

    public Task<Organisation> GetOrganisationByNameAndUserId(CreateOrganisationDto dto)
    {
        var orgExist = _context.Organisations.Where(o => o.OrganisationName == dto.Name
                                                         && o.UserId == dto.UserId);
        return orgExist.FirstOrDefaultAsync();
    }

    public Task AddOrganisationAsync(Organisation organisation)
    {
        _context.Organisations.Add(organisation);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public Task<int> GetDailySalesAsync(int orgId, DateTime from, DateTime to)
    {
        throw new NotImplementedException();
    }
    
}