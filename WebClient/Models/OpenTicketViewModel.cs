using System.ComponentModel.DataAnnotations;

public class OpenTicketViewModel{
    public int OrganisationId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
}