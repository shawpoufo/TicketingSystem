using ConversationAPI.DBContext;
using ConversationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConversationAPI.Repository;

public class MessageRepository{
    private readonly AppDbContext _context;
    public MessageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Message>> GetAllMessages(int ticketId) {
        return await _context.Set<Message>().Where(m => m.TicketId == ticketId).OrderByDescending(m => m.CreatedAt).ToListAsync();
    }
    public async Task Create(Message message){
        message.CreatedAt = DateTime.Now;
        await _context.Set<Message>().AddAsync(message);
        await _context.SaveChangesAsync();
    }
    

}