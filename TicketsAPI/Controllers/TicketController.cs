using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsAPI.Models;
using TicketsAPI.Repositories;

namespace TicketsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : ControllerBase
{
    private readonly TicketRepository _repository;

    public TicketController(TicketRepository repository)
    {
        _repository = repository;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Ticket>> GetById(int id)
    {
        var ticket = await _repository.GetById(id);

        if (ticket == null)
        {
            return NotFound();
        }

        return Ok(ticket);
    }

    [HttpGet("organisation/{id}")]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetAllByOrganisationId(int id)
    {
        var tickets = await _repository.GetAllByOrganisationId(id);

        if (tickets == null)
        {
            return NotFound();
        }

        return Ok(tickets);
    }


    [HttpPost]
    public async Task<ActionResult<Ticket>> Create(Ticket ticket)
    {
        ticket.CreatedAt = DateTime.Now;
        Console.WriteLine("====================================");
        Console.WriteLine(ticket.CreatedAt);
        Console.WriteLine("====================================");

        await _repository.Create(ticket);
        return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket);
    }

    [HttpPut("{id}/assign")]
    public async Task<IActionResult> Assign(int id,[FromBody] int agentId){
        Ticket? ticket = await _repository.GetById(id);
        if(ticket == null)
            return NotFound();

        ticket.AgentId = agentId;
        ticket.status = Status.Processing;
        await _repository.Update(ticket);
        return Ok(ticket);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id , [FromBody] JsonPatchDocument<Ticket> patchDoc){
        Ticket? ticket = await _repository.GetById(id);
        if(ticket == null)
            return NotFound();
        patchDoc.ApplyTo(ticket);
        await _repository.Update(ticket);
        return Ok(ticket);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ticket = await _repository.GetById(id);

        if (ticket == null)
        {
            return NotFound();
        }

        await _repository.Delete(id);
        return NoContent();
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetAllByUserId(int id){
        System.Console.WriteLine($"USER TICKET ID : {id}");
        var tickets = await _repository.GetAllByUserId(id);

        if(tickets == null)
        {
            System.Console.WriteLine("Maybe empty");
            return NotFound();
        }

        return Ok(tickets);

    }
    

    
}
