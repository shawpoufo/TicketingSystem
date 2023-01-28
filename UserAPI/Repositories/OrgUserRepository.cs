using UserAPI.AppDBContext;
using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UserAPI.Repositories;
public class OrgUserRepository{

    private readonly AppDbContext _context;

    public OrgUserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<OrgUser>> GetAllByOrganizationIdAndRole(int organisationId , int roleId){
        return await _context.Set<OrgUser>().Include(e => e.Role).Where( u => u.OrganisationsIds.Contains(organisationId) && u.Role.Id == roleId).ToListAsync();
    }

    public async Task Create(OrgUser user){
        await _context.Set<OrgUser>().AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<UserRole?> GetRoleById(int id){
        return await _context.Set<UserRole>().FirstOrDefaultAsync(r => r.Id == id);
    }


    
}