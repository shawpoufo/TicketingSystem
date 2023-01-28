
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

[Route("conversation")]
public class ConversationController : Controller{

    private readonly ConversationService _conversationService;
    private readonly IHubContext<ConversationHub,IConversationHub> _hubContext; 

    public ConversationController(ConversationService conversationService , IHubContext<ConversationHub,IConversationHub> hubContext)
    {
        _hubContext = hubContext;
        _conversationService = conversationService;
    }
    [HttpGet("{ticketId}")]
    [Produces("application/json")]
    public async Task<IActionResult> GetAll(int ticketId){
        var messages = await _conversationService.GetConversation(ticketId);
        return Ok(messages.Select(m =>{
            return new {
                m.Id,
                IOwnIt = m.UserId == User.GetId()!.Value,
                m.CreatedAt,
                m.Text
            };
        }));
    }
    [HttpPost]
    [Produces("application/json")]
    public async Task<IActionResult> Send([FromBody]MessageViewModel messageVM){
        if(!ModelState.IsValid)
            return BadRequest("Invalide data");
        try{
            var message = await _conversationService.create(User.GetId()!.Value,messageVM.TicketId,messageVM.Text);
            return Ok(message);
        }
        catch(Exception ex){
            return BadRequest();
        }
    }

}