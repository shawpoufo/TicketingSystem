using System.ComponentModel.DataAnnotations;

namespace CustomIdentityAPI.Models;

public class AppRole
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Label { get; set; }
}
