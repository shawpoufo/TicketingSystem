

namespace OrganisationAPI.Models;

public class Organisation{
    public int Id { get; set; }
    public string Name { get; set; }

    public int ManagerId { get; set; }

    public List<User> Users { get; set; } = new List<User>();
    
}