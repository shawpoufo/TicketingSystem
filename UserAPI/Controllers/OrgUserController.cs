using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UserAPI.Repositories;

namespace UserAPI.Controllers;

[ApiController]
[Route("users")]
public class OrgUserController : ControllerBase{

    public OrgUserRepository _repository  { get; set; }

    public OrgUserController(OrgUserRepository repository){
        _repository = repository;
    }

    [HttpGet("organisation/{organisationId}/role/{roleId}")]
    public async Task<IActionResult> GetAllByOrganizationIdAndRole(int organisationId , int roleId){
        var users = await _repository.GetAllByOrganizationIdAndRole(organisationId,roleId);
        return Ok(users);
    }
    [HttpPost]
    public async Task<IActionResult> Create(OrgUser user){
        var role = await _repository.GetRoleById(user.RoleId);
        await _repository.Create(user);
        return Created("",user);
    }

}
