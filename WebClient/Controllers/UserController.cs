
using WebClient.Services;
using Microsoft.AspNetCore.Mvc;

[Route("organisation/{orgId}/users" , Name ="users")]
public class UserController : Controller{

    private readonly OrganisationService _organisationService;
    private readonly UserService _userService;
    private readonly AuthService _authService;
    private readonly ConnectedUsers _connectedUsers;

    public UserController(OrganisationService organisationService,UserService userService,AuthService authService,ConnectedUsers connectedUsers)
    {
        _organisationService = organisationService;
        _userService = userService;
        _authService = authService;
        _connectedUsers = connectedUsers;
    }

    [HttpGet("clients",Name ="clients")]
    public async Task<IActionResult> Clients(int orgId){
        var org = await _organisationService.Get(orgId);

        return View("Users",new UserViewModel{
            OrganisationName = org.Name ,
            OrganisationId = org.Id ,
            RoleId = 1
            });
    }
    [HttpGet("agents",Name ="agents")]
    public async Task<IActionResult>  Agents(int orgId){
        var org = await _organisationService.Get(orgId);
        
        return View("Users",new UserViewModel{
            OrganisationName = org.Name ,
            OrganisationId = org.Id ,
            RoleId = 2
            });
    }

    [HttpPost("create",Name ="createUser")]
    public async Task<IActionResult> Create(UserViewModel model){
        if(!ModelState.IsValid){
            ViewData["Error"] = "Bad User Credentials";
            return View("Users",model);
        }
        var (success,userId) = await _authService.SignUp(model.UserName,model.Password,2);
        if(!success)
        {
            ViewData["Error"] = "User Already Existe";
            return View("Users",model);
        }
        success = await _userService.Create(userId,model.OrganisationId,model.Name,model.RoleId);
        if(!success)
            return BadRequest("Something Wrong");
        if (model.RoleId == 1)
            return  RedirectToRoute("clients",new{orgId=model.OrganisationId});
        
        return  RedirectToRoute("agents",new{orgId=model.OrganisationId});
        
    }
    [HttpGet("role/{roleId}")]
    public async Task<IActionResult> Get(int orgId,int roleId){
        var result = await _userService.GetMany(orgId,roleId);
        
        return Ok(result?.Select(u=>new {
            u.Id,
            u.Name,
            Status= _connectedUsers.Users.Exists(c => c.Id == u.Id) ? "Online" : "Offline"
        }));

    }

}