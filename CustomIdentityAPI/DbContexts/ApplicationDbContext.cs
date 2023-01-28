namespace CustomIdentityAPI.DbContexts;

using CustomIdentityAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class ApplicationDbContext : DbContext
{
    public DbSet<Login> Users { get; set; }
    public DbSet<AppRole> Roles { get; set; }
    public ApplicationDbContext(DbContextOptions options):base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.LogTo(Console.WriteLine);
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Login>()
            //     .HasOne<AppRole>()
            //     .WithMany()
            //     .HasForeignKey(l => l.RoleId);

            var adminRole = new AppRole{
                Id = 1,
                Label = "admin"
            };
            modelBuilder.Entity<AppRole>().HasData(adminRole);
            modelBuilder.Entity<AppRole>().HasData(new AppRole{
                Id = 2,
                Label = "User"
            });
            
            var hasher = new PwdHash();
            modelBuilder.Entity<Login>()
            .HasData(new {
                Id = 1,
                UserName = "admin",
                RoleId = 1,
                HashedPassword = hasher.ComputeHash("admin")
            });
            
            
        }
}
