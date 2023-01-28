using ConversationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConversationAPI.DBContext;

public class AppDbContext : DbContext{
    public DbSet<Message> Messages { get; set; }
    public AppDbContext(DbContextOptions options)
    :base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
}