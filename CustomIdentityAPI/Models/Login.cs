using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomIdentityAPI.Models;

public class Login
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(30)]
    public string UserName { get; set; }
    [Required]
    public string HashedPassword { get; set; }
    [Required]
    public int RoleId { get; set; }
    public AppRole Role { get; set; }

}
