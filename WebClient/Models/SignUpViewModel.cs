using System.ComponentModel.DataAnnotations;

namespace WebClient.Models;
public class SignUpViewModel
{
    [Required]
    public string UserName { get; set; }
    [Compare("RepeatedPassword")]
    public string Password { get; set; }
    public string RepeatedPassword { get; set; }
}