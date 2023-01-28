namespace TicketsAPI.DbContext;
using Microsoft.EntityFrameworkCore;
using TicketsAPI.Models;

public class AppDbContext:DbContext{
    public DbSet<Ticket> Tickets { get; set; }
    public AppDbContext(DbContextOptions options):base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        List<Ticket> ls  = new List<Ticket>();

        for(int i = 1 ; i <= 30 ; i ++){
            ls.Add(new Ticket{
                    Id=i,
                    Description="aaaaaaaaaa",
                    Title="title"+i,
                    ClientId=2,
                    CreatedAt= DateTime.UtcNow,
                    OrganisationId=1,
                    status = Status.New
                });
        }
        for(int i = 31 ; i <= 61 ; i ++){
            ls.Add(new Ticket{
                    Id=i,
                    Description="bbbbbbbb",
                    Title="title"+i,
                    ClientId=2,
                    CreatedAt= DateTime.UtcNow,
                    OrganisationId=1,
                    status = Status.Processing
                });
        }
        for(int i = 62 ; i <= 92 ; i ++){
            ls.Add(new Ticket{
                    Id=i,
                    Description="cccccccccc",
                    Title="title"+i,
                    ClientId=2,
                    CreatedAt= DateTime.UtcNow,
                    OrganisationId=1,
                    status = Status.Closed
                });
        }
        modelBuilder.Entity<Ticket>()
            .HasData(ls);
        
    }
    
}