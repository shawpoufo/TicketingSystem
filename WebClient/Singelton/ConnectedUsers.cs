
public class ConnectedUsers{

    public List<OrgUser> Users { get; set; }
    public List<(int managerId,int organisationId)> Managers { get; set; }

    public ConnectedUsers()
    {
        Users = new List<OrgUser>();
        Managers = new List<(int managerId, int organisationId)>();
    }
}
