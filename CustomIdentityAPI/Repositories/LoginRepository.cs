using CustomIdentityAPI.DbContexts;
using CustomIdentityAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace CustomIdentityAPI.Repositories;

public class LoginRepository {
    private ApplicationDbContext _dbContext;
    private PwdHash _hasher;

    public LoginRepository(ApplicationDbContext applicationDbContext , PwdHash hasher) 
    {
        _dbContext = applicationDbContext;
        _hasher = hasher;
    }

    public Task<Login?> Find(string userName , string password)
    {
        var h = _hasher.ComputeHash(password);

        return _dbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => 
            u.UserName == userName && 
            u.HashedPassword == h
            );
    }

    public async Task<Login> Create(string username , string password , int roleId){
        var user = await Find(username,password);
        if(user != null)
            throw new AlreadyAvailableCredentials("Another user alread has those credentials");
        
        var newUser = await _dbContext.Users.AddAsync(new Login{
          UserName = username,
          HashedPassword = _hasher.ComputeHash(password),
          RoleId = roleId
        });
        _dbContext.SaveChanges();
        return newUser.Entity;
    }
}
public class AlreadyAvailableCredentials : Exception{
    public AlreadyAvailableCredentials(string message):
        base(message)
    {
        
    }
} 