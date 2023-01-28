
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebClient.Models;
public class OrganisationViewModel{
    public int Id {get ;set;}
    public string Name { get; set; }

    public int UserCount { get; set; }

    public List<SelectListItem> Agents { get; set; }
}