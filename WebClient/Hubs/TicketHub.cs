using Microsoft.AspNetCore.SignalR;
using WebClient.Models;

namespace WebClient.Hubs;

public class TicketHub : Hub<ITicketHub>
{
    public async Task JoinTicketHub(int ticketId){
        await Groups.AddToGroupAsync(Context.ConnectionId,ticketId.ToString());
    }    

    public async Task Send(Message message){
       await Clients.OthersInGroup(message.TicketId.ToString()).ReceiveMessage(message);
    }
}