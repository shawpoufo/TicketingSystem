
using System.ComponentModel.DataAnnotations;

public class UserFormViewModel{
    [Required]
    public int OrganisationId { get; set; }
    [Required]

    public string UserName { get; set; }
    [Required]

    public string Name { get; set; }
    [Required]

    public string Password { get; set; }
    [Required]

    public int RoleId { get; set; }
}