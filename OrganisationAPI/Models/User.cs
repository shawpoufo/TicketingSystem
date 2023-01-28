namespace OrganisationAPI.Models;

public class User{
    public int Id { get; set; }
    public required string Name { get; set; }

    public int OrganisationId { get; set; }
    public int RoleId { get; set; }
}