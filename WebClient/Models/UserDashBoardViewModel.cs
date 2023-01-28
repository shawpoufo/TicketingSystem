using System.ComponentModel.DataAnnotations;

public class UserDashBoardViewModel{
    public string OrganisationName { get; set; }
    public int RoleId { get; set; }
    public OpenTicketViewModel OpenTicketVM { get; set; }

}