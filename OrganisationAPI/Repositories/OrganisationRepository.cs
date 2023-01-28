using OrganisationAPI.AppDBContext;
using Microsoft.EntityFrameworkCore;
using OrganisationAPI.Models;

namespace OrganisationAPI.Repositories;
public class OrganisationRepository{

    private readonly AppDbContext _context;

    public OrganisationRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Organisation>> GetAllByManagerId(int managerId){
        return await _context.Set<Organisation>().Where( o => o.ManagerId == managerId).ToListAsync();
    }

    public async Task Create(Organisation organisation){
        await _context.Set<Organisation>().AddAsync(organisation);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Organisation organisation){
        _context.Set<Organisation>().Update(organisation);
        await _context.SaveChangesAsync();
    }

    public Task<Organisation?> Get(int id){
        return _context.Set<Organisation>().Include(o => o.Users).FirstOrDefaultAsync(o => o.Id == id);
    }

    
}