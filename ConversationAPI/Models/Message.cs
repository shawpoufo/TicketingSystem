namespace ConversationAPI.Models;

public class Message{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TicketId { get; set; }
    public string Text { get; set; }

    public DateTime CreatedAt { get; set; }
}