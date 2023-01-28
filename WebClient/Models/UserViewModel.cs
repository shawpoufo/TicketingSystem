
using System.ComponentModel.DataAnnotations;

public class UserViewModel{
    public string OrganisationName { get; set; }
    [Required]
    public int RoleId { get; set; }
    [Required]
    public int OrganisationId { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Password { get; set; }

    

    
}