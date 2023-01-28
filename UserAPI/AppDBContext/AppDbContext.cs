using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UserAPI.AppDBContext;

public class AppDbContext:DbContext{
    public DbSet<OrgUser> Users { get; set; }
    public DbSet<UserRole> Roles { get; set; }

    public AppDbContext(DbContextOptions options):base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<OrgUser>()
            .Property(u => u.OrganisationsIds)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(c => Convert.ToInt32(c))
            );
        modelBuilder.Entity<UserRole>()
            .HasData(
                new UserRole{Id=1,Label="manager"},
                new UserRole{Id=2,Label="agent"},
                new UserRole{Id=3,Label="client"}
            );
    }

      
    
}