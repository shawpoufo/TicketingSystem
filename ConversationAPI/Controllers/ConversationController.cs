using ConversationAPI.Models;
using ConversationAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ConversationAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ConversationController : ControllerBase{
    private readonly MessageRepository _repository ;

    public ConversationController(MessageRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{ticketId}")]
    public async Task<IActionResult> GetConversation(int ticketId){
        return Ok(await _repository.GetAllMessages(ticketId));
    }

    [HttpPost]
    public async Task<IActionResult> Create(Message message){
        await _repository.Create(message);
        return Ok(message);
    }

}