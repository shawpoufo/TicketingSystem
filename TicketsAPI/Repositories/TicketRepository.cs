namespace TicketsAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using TicketsAPI.DbContext;
using TicketsAPI.Models;

public class TicketRepository
{
    private readonly AppDbContext _context;

    public TicketRepository(AppDbContext context)
    {
        _context = context;
    }

    // public async Task<IEnumerable<Ticket>> GetAll()
    // {
    //     return await _context.Set<Ticket>().ToListAsync();
    // }

    public async Task<Ticket?> GetById(int id)
    {
        return await _context.Set<Ticket>().FindAsync(id);
    }

    public async Task<IEnumerable<Ticket>> GetAllByOrganisationId(int id)
    {
        return await _context.Set<Ticket>().Where(t => t.OrganisationId == id).OrderByDescending(t => t.CreatedAt).ToListAsync();
    }

    public async Task<IEnumerable<Ticket>> GetAllByAgentId(int id)
    {
        return await _context.Set<Ticket>().Where(t => t.AgentId == id).OrderByDescending(t => t.CreatedAt).ToListAsync();
    }

    public async Task<IEnumerable<Ticket>> GetAllByUserId(int id,Status status)
    {
        return await _context.Set<Ticket>().Where(t => 
            (t.ClientId == id || t.AgentId == id)
            && t.status == status)
            .OrderByDescending(t => t.CreatedAt).ToListAsync();
    }
    public async Task<IEnumerable<Ticket>> GetAllByUserId(int id)
    {
        return await _context.Set<Ticket>().Where(t => 
            t.ClientId == id || t.AgentId == id)
            .OrderByDescending(t => t.CreatedAt).ToListAsync();
    }
    public Task<Ticket?> GetByUserId(int userId ,int ticketId)
    {
        return _context.Set<Ticket>().FirstOrDefaultAsync(t =>t.Id == ticketId && (t.ClientId == userId || t.AgentId == userId));
    }

    public async Task Create(Ticket ticket)
    {
        ticket.CreatedAt  = DateTime.Now;
        await _context.Set<Ticket>().AddAsync(ticket);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Ticket ticket)
    {
        _context.Set<Ticket>().Update(ticket);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Delete(int id)
    {
        var ticket = await GetById(id);
        if(ticket == null)
            return false;
        _context.Set<Ticket>().Remove(ticket);
        
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> TicketExists(int id)
    {
        return await _context.Set<Ticket>().AnyAsync(e => e.Id == id);
    }
}
