using System.ComponentModel.DataAnnotations;

public class MessageViewModel{
    [Required]
    public string Text { get; set; }
    [Required]
    public int TicketId { get; set; }
}