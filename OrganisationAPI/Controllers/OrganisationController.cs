using Microsoft.AspNetCore.Mvc;
using OrganisationAPI.Models;
using OrganisationAPI.Repositories;

namespace OrganisationAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrganisationController : ControllerBase{

    public OrganisationRepository _repository  { get; set; }

    public OrganisationController(OrganisationRepository repository){
        _repository = repository;
    }

    [HttpGet("manager/{managerId}")]
    public async Task<IActionResult> GetAllByManagerId(int managerId){
        IEnumerable<Organisation> organisations = await _repository.GetAllByManagerId(managerId);
        return Ok(organisations);
    }
    [HttpPost]
    public async Task<IActionResult> Create(Organisation org){
        await _repository.Create(org);
        return Created("",org);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id){
        var org = await _repository.Get(id);
        return Ok( new {org.Id,org.Name,UserCount=org.Users.Count()});
    }


}
