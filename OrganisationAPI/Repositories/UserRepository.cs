namespace OrganisationAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using OrganisationAPI.AppDBContext;
using OrganisationAPI.Models;

public class UserRepository{

    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(User user)
    {
        await _context.Set<User>().AddAsync(user);
        await _context.SaveChangesAsync();
    }
    public Task<List<User>> Get(int[] ids){
        return _context.Set<User>().Where(u => ids.Contains(u.Id)).ToListAsync();
    }
    public Task<User?> Get(int id){
        return _context.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
    }

    public Task<List<User>> Get(int orgId,int roleId){
        return _context.Set<User>().Where(u => u.OrganisationId == orgId && u.RoleId == roleId).ToListAsync();
    }
}