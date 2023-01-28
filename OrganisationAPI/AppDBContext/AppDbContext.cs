using Microsoft.EntityFrameworkCore;
using OrganisationAPI.Models;

namespace OrganisationAPI.AppDBContext;

public class AppDbContext:DbContext{
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public AppDbContext(DbContextOptions options):base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Role>()
            .HasData(new Role{Id = 1 , Title = "Client"},new Role{Id = 2, Title = "Agent"});
    }
}