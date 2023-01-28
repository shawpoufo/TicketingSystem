namespace WebClient.Models;

public class TicketViewModel{
    public int Id { get; set; }
    public string Status { get; set; }
    public string CreatedAt { get; set; }
    public string ClientName { get; set; }
    public string? AgentName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
}
