using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UserAPI.Models;
public class OrgUser
{
    public int Id { get; set; }
    public List<int> OrganisationsIds { get; set; } = new List<int>();
    public int RoleId { get; set; }
    [BindNever]
    [ValidateNever]
    public UserRole Role { get; set; } // client agent manager 
}
