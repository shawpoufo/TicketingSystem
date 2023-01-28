
using System.ComponentModel.DataAnnotations;

public class SignUpModel{
    [Required]
    [StringLength(30)]
    public string UserName { get; set; }
    [Required]
    [StringLength(30)]
    public string Password { get; set; }
    [Required]
    public int RoleId { get; set; }


}