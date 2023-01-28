using WebClient.Models;

public interface ITicketHub{
    Task TicketAdded(TicketViewModel ticket);
    Task TicketAssigned(TicketViewModel ticket);
    Task TicketClosed(int ticketId);
    Task ReceiveMessage(Message message);
}