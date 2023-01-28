using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Newtonsoft.Json;
using WebClient.Hubs;
using WebClient.Models;

namespace WebClient.Controllers;

[Authorize]
[Route("[controller]")]
public class TicketController : Controller{
    private readonly IHubContext<TicketHub,ITicketHub> _hubContext;
    private readonly TicketService _ticketService;
    private readonly ConnectedUsers _connectedUsers;
    private readonly UserService _userService;
    public TicketController(IHubContext<TicketHub,ITicketHub> hubContext,TicketService ticketService,UserService userService,ConnectedUsers connectedUsers)
    {
        _hubContext = hubContext;
        _ticketService = ticketService;
        _userService = userService;
        _connectedUsers = connectedUsers;
    }
    [HttpGet("{organisationId}")]
    [Produces("application/json")]
    public async Task<ActionResult> GetAll(int organisationId){
        var tickets = await _ticketService.GetAll(organisationId);
        
        return Ok(tickets);
    }
    [HttpPost("{id}/assign/{agentId}")]
    public async Task<ActionResult> Assign(int id,int agentId){
        var (ticket,agent) = await _ticketService.Assign(id,agentId);
        if(ticket != null)
        {
            var user = await _userService.Get(ticket.ClientId);
            var ticketVM = new TicketViewModel{
                Id = ticket.Id,
                AgentName = agent.Name,
                ClientName = user.Name,
                CreatedAt = ticket.CreatedAt.ToShortDateString(),
                Description = ticket.Description,
                Status = ticket.status.ToString(),
                Title = ticket.Title
            };
            await _hubContext.Clients.Group(ticket.Id.ToString()).TicketAssigned(ticketVM);
            await _hubContext.Clients.User(ticket.AgentId!.Value.ToString()).TicketAssigned(ticketVM);
            return Ok(new {Id = ticket.Id,AgentId = ticket.AgentId,Status = ticket.status.ToString(),AgentName=agent.Name});
        }
        
        return BadRequest();
    }
    [HttpGet("user")]    
    public async Task<IActionResult> GetAllByUser(){
    
        var tickets = await _ticketService.GetAllByUserId(User.GetId()!.Value);
        return Ok(tickets);
    }
    [HttpPost]
    [Produces("application/json")]
    public async Task<IActionResult> Create([FromBody]OpenTicketViewModel model){
        if(!ModelState.IsValid)
            return BadRequest("Invalide form data");
        var (isSucceed,ticket) = await _ticketService.create(User.GetId()!.Value,model.OrganisationId,model.Title,model.Description);
        if(!isSucceed || ticket == null)
            return BadRequest("Something went wrong");
        var client = await _userService.Get(User.GetId()!.Value);
        var ticketVM = new TicketViewModel{
            Id = ticket.Id,
            AgentName = "",
            ClientName = client?.Name ?? "",
            CreatedAt = ticket.CreatedAt.ToShortDateString(),
            Description = ticket.Description,
            Title = ticket.Title,
            Status = "New"
        };
        foreach(var manager in _connectedUsers.Managers)
        {
            if(manager.organisationId == ticket.OrganisationId)
            {
                await _hubContext.Clients.User(manager.managerId.ToString()).TicketAdded(ticketVM);
                break;
            }

        }
        return Ok(ticketVM);
    }

    [HttpPost("close/{id}")]
    public async Task<ActionResult> Close(int id){
        // I need to verify if the user own the ticket before closing it :)
        var isSucceed = await _ticketService.Close(id,User.GetId()!.Value);
        if(!isSucceed)
            return BadRequest();

        await _hubContext.Clients.Group(id.ToString()).TicketClosed(id);
        var user = await _userService.Get(User.GetId()!.Value);
        
        if(user == null)
            return BadRequest();

        foreach(var manager in _connectedUsers.Managers)
        {
            if(manager.organisationId == user.OrganisationId)
            {
                await _hubContext.Clients.User(manager.managerId.ToString()).TicketClosed(id);
                break;
            }
        }
        return Ok();

    }

}