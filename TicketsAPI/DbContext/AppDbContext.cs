namespace TicketsAPI.DbContext;
using Microsoft.EntityFrameworkCore;
using TicketsAPI.Models;

public class AppDbContext:DbContext{
    public DbSet<Ticket> Tickets { get; set; }
    public AppDbContext(DbContextOptions options):base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    
    
}
