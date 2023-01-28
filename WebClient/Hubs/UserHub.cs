using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

public class UserHub : Hub<IUserHub>{

    private readonly UserService _userService;
    private readonly ConnectedUsers _connectedUsers;

    public UserHub(UserService userService,ConnectedUsers connectedUsers):base()
    {
        _userService = userService;
        _connectedUsers = connectedUsers;
    }
    public async Task JoinOrganisationHub(UserService userService){
        if(Context.UserIdentifier == null)
            return;
        var userOrg = await userService.Get(Convert.ToInt32(Context.UserIdentifier));
        if(userOrg != null)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId,userOrg.OrganisationId.ToString());
            // basicly i should change this
            // i should send notification only to admin but i'm aware of database call
            // that may slow the request :) idk
            _connectedUsers.Users.Add(userOrg);
            await Clients.OthersInGroup(userOrg.OrganisationId.ToString()).UserConnected(Context.UserIdentifier);
        }
    }

    [Authorize("admin")]
    public async Task<List<OrgUser>> GetAllConnected(int organisationId){
        _connectedUsers.Managers.Add((Convert.ToInt32(Context.UserIdentifier),organisationId));
        await Groups.AddToGroupAsync(Context.ConnectionId,organisationId.ToString());
        return await Task.Run<List<OrgUser>>(()=>_connectedUsers.Users.Where(u => u.OrganisationId == organisationId).ToList());
    }


    public override async Task OnDisconnectedAsync(Exception? exception)
    {

        var userOrg = _connectedUsers.Users.FirstOrDefault(u => u.Id == Convert.ToInt32(Context.UserIdentifier));
        if(userOrg != null)
        {
            _connectedUsers.Users.Remove(userOrg);
            await Clients.OthersInGroup(userOrg.OrganisationId.ToString()).UserDisConnected(Context.UserIdentifier);
        }

        foreach(var entry in _connectedUsers.Managers){
            if(entry.managerId == Convert.ToInt32(Context.UserIdentifier)){
                _connectedUsers.Managers.Remove(entry);
                break;
            }
        }
        
        await base.OnDisconnectedAsync(exception);
    }



}