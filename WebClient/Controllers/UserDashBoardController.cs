using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class UserDashBoardController : Controller{

    private readonly OrganisationService _organisationService;
    private readonly UserService _userService;
    
    public UserDashBoardController(OrganisationService organisationService,UserService userService)
    {
        _organisationService = organisationService;
        _userService = userService;
    }
    public async Task<IActionResult> Index(){
        var usr = await _userService.Get(User.GetId()!.Value);
        var org = await _organisationService.Get(usr.OrganisationId);

        return View("Index",new UserDashBoardViewModel{
            OrganisationName = org.Name,
            RoleId = usr.RoleId,
            OpenTicketVM = new OpenTicketViewModel{OrganisationId = org.Id}
        });
    }
}