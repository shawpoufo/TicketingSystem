
using Microsoft.AspNetCore.Mvc;
using OrganisationAPI.Models;
using OrganisationAPI.Repositories;

namespace OrganisationAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase{

    private UserRepository _repo;

    public UserController(UserRepository repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user){
        await _repo.Create(user);
        return Ok();
    }
    public async Task<IActionResult> Get([FromQuery]int[] ids){
        var users = await _repo.Get(ids);
        return Ok(users);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id){
        var user = await _repo.Get(id);
        return Ok(user);
    }
    [HttpGet("organisation/{orgId}/role/{roleId}")]
    public async Task<IActionResult> Get(int orgId,int roleId){
        return Ok(await _repo.Get(orgId,roleId));
    }
    

}
