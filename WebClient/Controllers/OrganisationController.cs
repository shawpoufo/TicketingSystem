
using WebClient.Models;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

[Authorize("admin")]
[Route("[controller]")]
public class OrganisationController : Controller{
    private readonly OrganisationService _organisationService;
    private readonly UserService _userService;

    public OrganisationController(OrganisationService organisationService,UserService userService)
    {
        _organisationService = organisationService;
        _userService = userService;
    }
    [HttpGet] 
    public async Task<IActionResult> Index(){
        var organisations = await _organisationService.GetAllByManagerId(User.GetId()!.Value);
        return View((organisations,User.GetId()!.Value));
    }
    [HttpGet("{id}")] 
    public async Task<IActionResult> Detail(int id){
        var org = await _organisationService.Get(id);
        var agents = await _userService.GetMany(org.Id,2);
        List<SelectListItem> agentList = agents.Select(a => new SelectListItem{Text = a.Name,Value=a.Id.ToString()}).ToList();
        agentList.Insert(0,new SelectListItem{Text="Please select one",Value="-1",Selected=true});
        return View(new OrganisationViewModel{Id = org.Id,Name = org.Name,UserCount= org.userCount,Agents =agentList});
    }

    [HttpPost]
    public async Task<IActionResult> Create(OrganisationViewModel model){
        var organisation = await _organisationService.create(User.GetId()!.Value,model.Name);
        return RedirectToAction(nameof(Index));
    }

}