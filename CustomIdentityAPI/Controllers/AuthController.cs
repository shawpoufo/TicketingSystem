using CustomIdentityAPI.DbContexts;
using CustomIdentityAPI.Models;
using CustomIdentityAPI.Models;
using CustomIdentityAPI.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace CustomIdentityAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController:ControllerBase{

    private ApplicationDbContext _dbContext;
    private LoginRepository _repository;
    private PasswordHasher<Login> _hasher;

    public AuthController(ApplicationDbContext context , PasswordHasher<Login> hasher,LoginRepository repository)
    {
        _dbContext=context;
        _hasher = hasher;
        _repository = repository;
    }
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(SignUpModel model){
        Login? user = null;
        try{
            user = await _repository.Create(model.UserName,model.Password,model.RoleId);
        }catch(AlreadyAvailableCredentials ex){
            System.Console.WriteLine(ex.Message);
            return BadRequest(ex.Message);
        }
        
        return Created("",user.Id);
    }

    [HttpPost("Login")]
    public  async Task<IActionResult> Login(LoginModel loginModel){
        var usr = await _repository.Find(loginModel.UserName,loginModel.Password);
        
        if(usr == null)
            return NotFound();
        var claims = new List<Claim>{
            new Claim(ClaimTypes.NameIdentifier,usr.Id.ToString()),
            new Claim(ClaimTypes.Name,usr.UserName),
            new Claim(ClaimTypes.Role,usr.Role.Label),
        };
        // var claimIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
        var claimIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

        var ClaimsPrincipal = new ClaimsPrincipal(claimIdentity);

        this.HttpContext.Response.Headers.Add("role",usr.Role.Label);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,ClaimsPrincipal);
        
        return Ok();
    }

    [Authorize]
    public IActionResult Hi()
    {
        return Ok();
    }

}
